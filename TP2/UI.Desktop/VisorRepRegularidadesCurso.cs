using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Business.Entities;
using Business.Logic;
namespace UI.Desktop
{
    public partial class VisorRepRegularidadesCur : Form
    {
        private List<ReportParameter> parametros;
        List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> alumnos;

        public VisorRepRegularidadesCur(PersonaLogic.PersonaExtended oDocente, CursoLogic.CursoExtended oCurso, string oEspecialidad, List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> alumnos)
        {
            InitializeComponent();


            this.alumnos = alumnos;

            // Carga de parametros para el Reporte.
            this.parametros = new List<ReportParameter>();
            this.parametros.Add(new ReportParameter("paramPlanNombre", oDocente.Plan));
            this.parametros.Add(new ReportParameter("paramMateriaNomb", oCurso.Materia));
            this.parametros.Add(new ReportParameter("paramComisionDesc", oCurso.Comision));
            this.parametros.Add(new ReportParameter("paramEspecialidadDesc", oEspecialidad));
            this.parametros.Add(new ReportParameter("paramDocenteNomApe", oDocente.Apellido + " " + oDocente.Nombre));
            this.parametros.Add(new ReportParameter("paramDocenteLeg", oDocente.Legajo.ToString()));
        }

        private void cargarReporte() 
        {
            this.rvReportesAcademia.LocalReport.DataSources.Clear();

            

            this.rvReportesAcademia.LocalReport.DataSources.Add(new ReportDataSource("Alumnos_Inscriptos", this.alumnos));
            this.rvReportesAcademia.LocalReport.SetParameters(parametros);
            this.rvReportesAcademia.RefreshReport();
        }

        private void VisorRepRegularidadesCur_Load(object sender, EventArgs e)
        {
            this.cargarReporte();
        }

    }
}
