using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class CargarNotasCurso : Form
    {
        private persona docenteActual;
        private int IdCurso;

        public CargarNotasCurso(persona docente, int IdCurso)
        {
            InitializeComponent();

            this.docenteActual = docente;
            this.IdCurso = IdCurso;
            this.lblApellidoDocente.Text = this.docenteActual.apellido;

            this.dgvAlumnosDelCurso.AutoGenerateColumns = false;

            this.GenerarColumnas();
        }

        private void GenerarColumnas()
        {
            int[] numeracion = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            DataGridViewColumn dgvc;
            //dgvc = ListarBase.CrearNuevaColumna("nota","Nota","Nota");
            dgvc = ListarBase.CrearNuevaColumna(ListarBase.typeColumn.COMBOBOX, "nota", "Nota", "Nota", "Nota", numeracion);
            this.dgvAlumnosDelCurso.Columns.Add(dgvc);

            dgvc = ListarBase.CrearNuevaColumna(ListarBase.typeColumn.COMBOBOX, "condicion", "Condicion", "Condicion", "Condicion", Enum.GetNames(typeof(alumnos_inscripciones.tipoCondicion)));
            this.dgvAlumnosDelCurso.Columns.Add(dgvc);

            dgvc = ListarBase.CrearNuevaColumna("alumno", "Alumno", "Alumno");
            dgvc.ReadOnly = true;
            this.dgvAlumnosDelCurso.Columns.Add(dgvc);

            dgvc = ListarBase.CrearNuevaColumna("legajo", "Legajo", "Legajo");
            dgvc.ReadOnly = true;
            this.dgvAlumnosDelCurso.Columns.Add(dgvc);

            dgvc = ListarBase.CrearNuevaColumna("idInscripcion", "Id Inscripcion", "Id_inscripcion");
            dgvc.Visible = false;
            this.dgvAlumnosDelCurso.Columns.Add(dgvc);
        }

        private void Listar()
        {
            InscripcionAlumnoLogic aiLogic = new InscripcionAlumnoLogic();
            this.dgvAlumnosDelCurso.DataSource = InscripcionAlumnoLogic.getAlumnosInscripcionesExtended(
                aiLogic.GetAlumnosDeCurso(IdCurso));
        }

        private void GuardarCambios() 
        { 
            // Recupero el datasource y los mando a la capa logica ---> capa datos --- > linQ.
            // Agregar Boton Guardar.

            List<alumnos_inscripciones> inscripciones = new List<alumnos_inscripciones>();

            foreach (DataGridViewRow fila in this.dgvAlumnosDelCurso.Rows)
            {
                alumnos_inscripciones insc = new alumnos_inscripciones();

                insc.id_inscripcion = int.Parse(fila.Cells["idInscripcion"].Value.ToString());
                insc.condicion = fila.Cells["condicion"].Value.ToString();

                // Valido que nota no este null para evitar error de NullReference al convertir a int.
                object nota = fila.Cells["nota"].Value;
                if (nota != null) insc.nota = int.Parse(nota.ToString());

                inscripciones.Add(insc);
            }

            InscripcionAlumnoLogic insAlumLogic = new InscripcionAlumnoLogic();
            insAlumLogic.Save(inscripciones);
        }

        private void CargarNotasCurso_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
            this.Close();
        }

        private List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> GetDatosDeGrilla()
        {
            List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> alumnos = new List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent>();

             foreach (DataGridViewRow fila in this.dgvAlumnosDelCurso.Rows)
             {
                 InscripcionAlumnoLogic.InscripcionAlumnoExtendent insc = new InscripcionAlumnoLogic.InscripcionAlumnoExtendent();

                 insc.Legajo = int.Parse(fila.Cells["legajo"].Value.ToString());
                 insc.Alumno = fila.Cells["alumno"].Value.ToString();
                 insc.Condicion = fila.Cells["condicion"].Value.ToString();                     
                 // Valido que nota no este null para evitar error de NullReference al convertir a int.
                 object nota = fila.Cells["nota"].Value;
                 if (nota != null) insc.Nota = int.Parse(nota.ToString());

                 alumnos.Add(insc);
             }

             return alumnos;
        }

        private void btnImprReporte_Click(object sender, EventArgs e)
        {
            this.EmitirReporte();
        }

        private void EmitirReporte()
        {
            PersonaLogic perLogic = new PersonaLogic();
            PersonaLogic.PersonaExtended oDocente = PersonaLogic.getPersonaExtended(perLogic.GetOne(this.docenteActual.id_persona));

            CursoLogic curLogic = new CursoLogic();
            CursoLogic.CursoExtended oCurso = CursoLogic.getCursoExtended(curLogic.GetOne(this.IdCurso));

            // Falta enviar la especialidad de la materia.

            VisorRepRegularidadesCur vrRegularidades = new VisorRepRegularidadesCur(oDocente, oCurso,"Pruebas especialidad", this.GetDatosDeGrilla());
            vrRegularidades.ShowDialog();
        }
    }//end class
}
