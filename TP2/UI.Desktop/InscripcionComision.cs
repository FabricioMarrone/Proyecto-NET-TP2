using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using System.Collections;
using System.Reflection;

namespace UI.Desktop
{
    public partial class InscripcionComision : ApplicationForm
    {
        private materia oMateria;
        private alumnos_inscripciones inscripcionActual;
        public InscripcionComision()
        {
            InitializeComponent();
        }

        public InscripcionComision(materia oMateria, int id_persona)
            : this()
        {
            // Cambiar el label de inscripcion a materia tal por NombreMateria.
            this.inscripcionActual = new alumnos_inscripciones();
            this.inscripcionActual.id_alumno = id_persona;
//-----------> Faltaria establecer una enumeracion para las condiciones del alumno.
            this.inscripcionActual.condicion = "Inscripto";// Solucion provisoria.

            this.oMateria = oMateria;
            this.lblMateria.Text = this.oMateria.desc_materia;
        }

        public void Listar()
        {
            CursoLogic cursoLogic = new CursoLogic();

            IList comisiones = cursoLogic.GetCursosParaInscripcion(oMateria.id_materia);
            // Recuperar las comisiones con que tenga cupo para inscribirse.
            if (comisiones != null)
            {
                int y = 0;

                RadioButton rbComision;
                foreach (Object com in comisiones)
                {
                    y += 20;
                    rbComision = new RadioButton();
                    rbComision.Location = new System.Drawing.Point(9, 0 + (y));

                    PropertyInfo propiedad;
                    //Obtengo la propiedad el valor de la propiedad IdCurso del Tipo Anonimo.
                    propiedad = (com.GetType()).GetProperty("IdCurso");
                    rbComision.Name = (propiedad.GetValue(com, null)).ToString();
                    rbComision.TabIndex = 0;
                    rbComision.BackColor = System.Drawing.Color.Transparent;

                    //Obtengo la propiedad el valor de la propiedad DescripcionCurso del Tipo Anonimo.
                    propiedad = (com.GetType()).GetProperty("DescripcionComision");
                    rbComision.Text = (propiedad.GetValue(com, null)).ToString();

                    this.gbComisiones.Controls.Add(rbComision);           
                }
            }
            else
            {
                this.Notificar("No hay comisiones con cupo", "No existen comisiones con cupos disponibles para su inscripcion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void CompletarIncripcion(int idCurso) 
        {
            try
            {
                this.inscripcionActual.id_curso = idCurso;
                InscripcionAlumnoLogic inscLogic = new InscripcionAlumnoLogic();
                inscLogic.Save(inscripcionActual, "Alta");
            }
            catch (Exception)
            {
                MessageBox.Show("Error en el metodo btnAceptar_Click de Clase InscripcionComision");
            }        
        }

        private void InscripcionComision_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.gbComisiones.Controls)
            {
                if ((control as RadioButton).Checked) 
                {
                    this.CompletarIncripcion(int.Parse(control.Name));
                    this.Close();
                }
                // ?????????
                // Deberia mostrarse un aviso "Seleccione una comision de cursado."
            }
        }
    }
}
