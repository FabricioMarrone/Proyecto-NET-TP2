﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class CargarNotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                persona docente = (persona)this.Session[Global.PERSONA_ACTUAL];
                this.loadCursos(docente);
            }
        }

        protected void loadCursos(persona docente) 
        {
            DocenteCursoLogic logic = new DocenteCursoLogic();

            this.ddlCursos.DataSource = CursoLogic.getCursosExtended(logic.getCursosDelDocente(docente));
            this.ddlCursos.DataValueField = "id_curso";
            this.ddlCursos.DataTextField = "desc";
            this.ddlCursos.DataBind();

            this.ddlCursos_SelectedIndexChanged(null, null);
        }

        protected void ddlCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_curso = Int32.Parse(this.ddlCursos.SelectedValue);
            this.LoadGrid(id_curso);
        }

        private void LoadGrid(int id_curso)
        {
            this.GridPanel.Visible = true;
            this.ShowMessage();

            InscripcionAlumnoLogic aiLogic = new InscripcionAlumnoLogic();

            try
            {
                List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> inscripciones = InscripcionAlumnoLogic.getAlumnosInscripcionesExtended(aiLogic.GetAlumnosDeCurso(id_curso));
                this.grdAlumnos.DataSource = inscripciones;
                this.grdAlumnos.DataBind();

                int[] numeracion = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                for (int i = 0; i < this.grdAlumnos.Rows.Count; i++)
                {
                    GridViewRow row = this.grdAlumnos.Rows[i];
                    DropDownList ddlCondicion = (DropDownList)row.FindControl("ddlCondicion");
                    ddlCondicion.DataSource = Enum.GetNames(typeof(alumnos_inscripciones.tipoCondicion));
                    ddlCondicion.SelectedValue = inscripciones[i].Condicion;
                    ddlCondicion.DataBind();

                    DropDownList ddlNota = (DropDownList)row.FindControl("ddlNota");
                    ddlNota.DataSource = numeracion;
                    if (inscripciones[i].Nota == null) ddlNota.SelectedValue = "0";
                    else ddlNota.SelectedValue = inscripciones[i].Nota.ToString();
                    ddlNota.DataBind();
                }
            }
            catch (ListaEmptyException lee)
            {
                // Excepcion de list que no contiene instancias de inscripcionAlumnos
                this.ShowMessage(lee.Mensaje);
                this.GridPanel.Visible = false;
            }
            catch (Exception)
            {
                // Error Generico del cual no se que tipo es.
                this.ShowMessage("Se ha producido un error durante la carga de la pagina.");
                this.GridPanel.Visible = false;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            List<alumnos_inscripciones> inscripciones = new List<alumnos_inscripciones>();

            foreach (GridViewRow row in this.grdAlumnos.Rows)
            {
                alumnos_inscripciones insc = new alumnos_inscripciones();
                int id_inscripcion = Int32.Parse(row.Cells[0].Text);
                //Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('ID: " + row.Cells[0].Text + "')</SCRIPT>");
                insc.id_inscripcion = id_inscripcion;
                insc.condicion = ((DropDownList)row.Cells[3].FindControl("ddlCondicion")).SelectedValue;
                string nota = ((DropDownList)row.Cells[4].FindControl("ddlNota")).SelectedValue;
                if (nota != null) insc.nota = int.Parse(nota);

                inscripciones.Add(insc);
            }

            InscripcionAlumnoLogic insAlumLogic = new InscripcionAlumnoLogic();
            insAlumLogic.Save(inscripciones);
            this.ShowMessage("Notas registradas con exito.", true);
        }

        private void EmitirReporte()
        {
            int id_curso = Int32.Parse(this.ddlCursos.SelectedValue);
            CursoLogic curLogic = new CursoLogic();
            CursoLogic.CursoExtended oCurso = CursoLogic.getCursoExtended(curLogic.GetOne(id_curso));
            this.Session["oCurso"] = oCurso;

            persona pActual = (persona)this.Session[Global.PERSONA_ACTUAL];
            //if (this.Session["PERSONA_ACTUAL"] == null)
            //{
            //    this.Session["PERSONA_ACTUAL"] = pActual;
            //}

            PlanLogic planLogic = new PlanLogic();
            PlanLogic.PlanExtended oPlan = PlanLogic.getPlanExtended(planLogic.GetOne(pActual.id_plan));
            this.Session["oPlan"] = oPlan;

            this.Session["alumnos"] = this.GetDatosDeGrilla();

            Response.Write("<script language='javascript'> window.open('VisorRepRegularidadesCurso.aspx','','width=710,Height=600,fullscreen=0,location=0,scrollbars=1,menubar=0,toolbar=0'); </script>");
        }

        private List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> GetDatosDeGrilla() 
        {
            List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent> alumnos = new List<InscripcionAlumnoLogic.InscripcionAlumnoExtendent>();

            foreach (GridViewRow fila in this.grdAlumnos.Rows)
            {
                InscripcionAlumnoLogic.InscripcionAlumnoExtendent insc = new InscripcionAlumnoLogic.InscripcionAlumnoExtendent();

                // 0 id_inscirpcion
                // 1 legajo
                insc.Legajo = int.Parse(fila.Cells[1].Text);
                // 2 alumno
                insc.Alumno = fila.Cells[2].Text;
                // 3 = condicion
                //insc.Condicion = fila.Cells[3].Text;
                insc.Condicion = ((DropDownList)fila.Cells[3].FindControl("ddlCondicion")).SelectedValue;
                // 4 = nota.
                // Valido que nota no este null para evitar error de NullReference al convertir a int.

                string nota = ((DropDownList)fila.Cells[4].FindControl("ddlNota")).SelectedValue;
                if (nota != null) insc.Nota = int.Parse(nota);

                alumnos.Add(insc);
            }
            return alumnos;
        }

        private void ShowMessage() 
        {
            this.messageArea.Visible = false;
        }
        private void ShowMessage(string message) 
        {
            this.ShowMessage(message,false);
        }

        private void ShowMessage(string message, bool confirmacion)
        {
            if (confirmacion)
            {
                // Afirmativo
                this.messageArea.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                // Negativo
                this.messageArea.ForeColor = System.Drawing.Color.Red;
            }
            this.messageArea.Text = message;
            this.messageArea.Visible = true;
        }

        protected void btnImprReporte_Click(object sender, EventArgs e)
        {
            this.EmitirReporte();
        }
    }//end class
}