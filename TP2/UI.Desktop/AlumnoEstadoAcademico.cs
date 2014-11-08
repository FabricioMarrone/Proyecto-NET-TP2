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
    public partial class AlumnoEstadoAcademico : Form
    {
        persona personaActual;

        public AlumnoEstadoAcademico(persona per)
        {
            InitializeComponent();
            this.personaActual = per;

            this.CrearColumnas();
        }

        private void loadGrid() 
        {
            InscripcionAlumnoLogic logic= new InscripcionAlumnoLogic();
            this.dgvInscripciones.DataSource = logic.getInscripcionesDelAlumno(this.personaActual);
        }

        private void CrearColumnas() {
            DataGridViewColumn col;

            col = ListarBase.CrearNuevaColumna("nota", "Nota", "Nota");
            this.dgvInscripciones.Columns.Add(col);

            col = ListarBase.CrearNuevaColumna("condicion", "Condicion", "Condicion");
            this.dgvInscripciones.Columns.Add(col);

            col = ListarBase.CrearNuevaColumna("anio", "Año de cursado", "Año");
            this.dgvInscripciones.Columns.Add(col);

            col = ListarBase.CrearNuevaColumna("materia", "Materia", "NombreMateria");
            this.dgvInscripciones.Columns.Add(col);
        }

        private void AlumnoEstadoAcademico_Load(object sender, EventArgs e)
        {
            this.loadGrid();
        }

        private List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> GetDatosDeGrilla() 
        {
            List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> materias = new List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent>();

            foreach (DataGridViewRow fila in this.dgvInscripciones.Rows)
            {
                InscripcionAlumnoLogic.InscripcionAlumnoExtendent matInscrip = new InscripcionAlumnoLogic.InscripcionAlumnoExtendent();

                matInscrip.Materia = fila.Cells["materia"].Value.ToString();
                matInscrip.AnioCalendario = int.Parse(fila.Cells["anio"].Value.ToString());
                matInscrip.Condicion = fila.Cells["condicion"].Value.ToString();
                //Valido que nota no este null para evitar error de NullReference al convertir a int.
                object nota = fila.Cells["nota"].Value;
                if (nota != null) matInscrip.Nota = int.Parse(nota.ToString());

                materias.Add(matInscrip);
            }

            return materias;
        }

        private void EmitirReporte() 
        {
            PlanLogic planLogic = new PlanLogic();
            PlanLogic.PlanExtended planExt = PlanLogic.getPlanExtended(planLogic.GetOne(this.personaActual.id_plan));

            VisorRepEstadoAcad vrEstadoAcademico = new VisorRepEstadoAcad(this.personaActual, planExt, this.GetDatosDeGrilla());
            vrEstadoAcademico.ShowDialog();
        }

        private void btnEstadoAcad_Click(object sender, EventArgs e)
        {
            this.EmitirReporte();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }//end class
}
