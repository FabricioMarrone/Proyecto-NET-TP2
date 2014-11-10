using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;

namespace UI.Web
{
    public partial class VisorRepEstadoAcad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                persona oAlumno = (persona)this.Session["PERSONA_ACTUAL"];
                // Valido que quien entre sea un Alumno.
                if (oAlumno.tipo_persona == (int)persona.tipo.Alumno)
                {
                    this.cargarReporte(oAlumno);
                }
                else
                {
                    // Si no es Prof. se redirecciona a la pagina de Inicio.
                    this.Response.Redirect("/Home.aspx");
                }                
            }

        }
        private void cargarReporte(persona oAlumno)
        {
            PlanLogic.PlanExtended oPlan = (PlanLogic.PlanExtended)this.Session["oPlan"];
            List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> materias = (List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent>)this.Session["materias"];

            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("paramAlumNomApe", oAlumno.apellido + " " + oAlumno.nombre));
            parametros.Add(new ReportParameter("paramAlumLegajo", oAlumno.legajo.ToString()));
            parametros.Add(new ReportParameter("paramAlumPlan", oPlan.Desc_plan));
            parametros.Add(new ReportParameter("paramEspecialidad", oPlan.Especialidad));

            this.rvEstadoAcademico.LocalReport.DataSources.Clear();
            this.rvEstadoAcademico.LocalReport.DataSources.Add(new ReportDataSource("Materias",materias));
            this.rvEstadoAcademico.LocalReport.SetParameters(parametros);
        }
    }
}