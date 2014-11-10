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
    public partial class VisorRepRegularidadesCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (! Page.IsPostBack)
            {
//--------------->
                // Colocar Bloque try Cacht para ver si existe la session.
                persona oDocente = (persona)this.Session["PERSONA_ACTUAL"];
                // Valido que quien entre sea un profesor.
                if (oDocente.tipo_persona == (int)persona.tipo.Profesor)
                {
                    this.cargarReporte(oDocente);
                }
                else
                {
                    // Si no es Prof. se redirecciona a la pagina de Inicio.
                    this.Response.Redirect("/Home.aspx");
                }

            }

        }

        private void cargarReporte(persona oDocente)
        {

            PlanLogic.PlanExtended oPlan = (PlanLogic.PlanExtended)this.Session["oPlan"];
            CursoLogic.CursoExtended oCurso = (CursoLogic.CursoExtended)this.Session["oCurso"];
            List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> alumnos = (List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent>)this.Session["alumnos"];

            // Carga de parametros para el Reporte.
            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("paramPlanNombre", oPlan.Desc_plan));
            parametros.Add(new ReportParameter("paramMateriaNomb", oCurso.Materia));
            parametros.Add(new ReportParameter("paramComisionDesc", oCurso.Comision));
            parametros.Add(new ReportParameter("paramEspecialidadDesc", oPlan.Especialidad));
            parametros.Add(new ReportParameter("paramDocenteNomApe", oDocente.apellido + " " + oDocente.nombre));
            parametros.Add(new ReportParameter("paramDocenteLeg", oDocente.legajo.ToString()));


            this.rvReportesAcademia.LocalReport.DataSources.Clear();
            this.rvReportesAcademia.LocalReport.DataSources.Add(new ReportDataSource("Alumnos_Inscriptos", alumnos));
            this.rvReportesAcademia.LocalReport.SetParameters(parametros);
            //this.rvReportesAcademia.Repo
        }




    }
}