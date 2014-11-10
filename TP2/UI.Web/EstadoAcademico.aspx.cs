using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class EstadoAcademico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.loadGrid();
        }

        private void loadGrid() 
        {
            InscripcionAlumnoLogic logic = new InscripcionAlumnoLogic();
            persona per= (persona)this.Session[Global.PERSONA_ACTUAL];
            this.grdEstadoAcademico.DataSource = logic.getInscripcionesDelAlumno(per);
            this.grdEstadoAcademico.DataBind();
        }

        private void EmitirReporte()
        {
            persona personaActual = (persona)this.Session[Global.PERSONA_ACTUAL];
            if (this.Session["PERSONA_ACTUAL"] == null)
            {
                this.Session["PERSONA_ACTUAL"] = personaActual;
            }

            PlanLogic planLogic = new PlanLogic();
            PlanLogic.PlanExtended planExt = PlanLogic.getPlanExtended(planLogic.GetOne(personaActual.id_plan));

            this.Session["oPlan"] = planExt;

            //int id_curso = Int32.Parse(this.ddlCursos.SelectedValue);
            //CursoLogic curLogic = new CursoLogic();
            //CursoLogic.CursoExtended oCurso = CursoLogic.getCursoExtended(curLogic.GetOne(id_curso));
            //this.Session["oCurso"] = oCurso;



            //PlanLogic planLogic = new PlanLogic();
            //PlanLogic.PlanExtended oPlan = PlanLogic.getPlanExtended(planLogic.GetOne(pActual.id_plan));
            //this.Session["oPlan"] = oPlan;

            this.Session["materias"] = this.GetDatosDeGrilla();

            Response.Redirect("~/VisorRepEstadoAcad.aspx");
        }

        private List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> GetDatosDeGrilla()
        {
            List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> alumnos = new List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent>();

            foreach (GridViewRow fila in this.grdEstadoAcademico.Rows)
            {
                InscripcionAlumnoLogic.InscripcionAlumnoExtendent matInscrip = new InscripcionAlumnoLogic.InscripcionAlumnoExtendent();

                // 1 = NombreMateria
                matInscrip.Materia = fila.Cells[0].Text;
                // 2 = Año	
                matInscrip.AnioCalendario = int.Parse(fila.Cells[1].Text);
                // 3 = Condicion
                matInscrip.Condicion = fila.Cells[2].Text;
                // 4 = Nota
                string nota = Regex.Replace(fila.Cells[3].Text, @"&nbsp;", "");
                if ( !String.IsNullOrWhiteSpace(nota) ) matInscrip.Nota = int.Parse(nota);

                alumnos.Add(matInscrip);
            }
            return alumnos;
        }

        protected void btnEstadoAcad_Click(object sender, EventArgs e)
        {
            this.EmitirReporte();
        }
    }//end class
}