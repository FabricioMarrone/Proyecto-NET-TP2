using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class VisorRepEstadoAcad : Form
    {
        private List<ReportParameter> parametros;
        private List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> materias;

        public VisorRepEstadoAcad(persona oAlumno, PlanLogic.PlanExtended oPlan, List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> materias)
        {
            InitializeComponent();
            this.materias = materias;

            this.parametros = new List<ReportParameter>();
            this.parametros.Add(new ReportParameter("paramAlumNomApe",oAlumno.apellido + " " +oAlumno.nombre));
            this.parametros.Add(new ReportParameter("paramAlumLegajo",oAlumno.legajo.ToString()));
            this.parametros.Add(new ReportParameter("paramAlumPlan",oPlan.Desc_plan));
            this.parametros.Add(new ReportParameter("paramEspecialidad", oPlan.Especialidad));
        }

        private void CargarReporte() 
        {
            this.rvEstadoAcademico.LocalReport.DataSources.Clear();
            this.rvEstadoAcademico.LocalReport.DataSources.Add(new ReportDataSource("Materias",this.materias));
            this.rvEstadoAcademico.LocalReport.SetParameters(parametros);
            this.rvEstadoAcademico.RefreshReport();
        }

        private void VisorRepEstadoAcad_Load(object sender, EventArgs e)
        {
            this.CargarReporte();
        }
    }
}
