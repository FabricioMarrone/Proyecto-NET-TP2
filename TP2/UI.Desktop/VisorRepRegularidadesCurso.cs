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
        private List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> alumnos;

        public VisorRepRegularidadesCur(persona oDocente, CursoLogic.CursoExtended oCurso, PlanLogic.PlanExtended oPlan, List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> alumnos)
        {
            InitializeComponent();


            this.alumnos = alumnos;

            // Carga de parametros para el Reporte.
            this.parametros = new List<ReportParameter>();
            this.parametros.Add(new ReportParameter("paramPlanNombre", oPlan.Desc_plan));
            this.parametros.Add(new ReportParameter("paramMateriaNomb", oCurso.Materia));
            this.parametros.Add(new ReportParameter("paramComisionDesc", oCurso.Comision));
            this.parametros.Add(new ReportParameter("paramEspecialidadDesc", oPlan.Especialidad));
            this.parametros.Add(new ReportParameter("paramDocenteNomApe", oDocente.apellido + " " + oDocente.nombre));
            this.parametros.Add(new ReportParameter("paramDocenteLeg", oDocente.legajo.ToString()));
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
