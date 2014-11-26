using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class InscripcionAmateria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.loadMaterias();
            }


            string msg = this.Request.QueryString["msg"];
            if (msg != null && msg == "yes")
            {
                this.messageArea.Text = "Inscripcion registrada correctamente.";
                this.messageArea.Visible = true;
                //Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Inscripcion registrada correctamente.')</SCRIPT>");
            }
        }

        private void loadMaterias() 
        {
            this.messageArea.Text = string.Empty;
            this.messageArea.Visible = false;

            persona personaActual = (persona)this.Session[Global.PERSONA_ACTUAL];
            MateriaLogic materiaLogic = new MateriaLogic();
            IList mats = materiaLogic.GetMateriasParaInscripcion(personaActual);
            if (mats.Count == 0)
            {
               this.lblMsg.Text = "No hay materias disponibles para inscripción.";
               this.grdMateriass.Visible = false;
               return;
            }

            this.grdMateriass.DataSource = mats;
            this.grdMateriass.DataBind();
        }

        protected void grdMateriass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Inscribirme")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = this.grdMateriass.Rows[index];
                int id_materia = Int32.Parse(row.Cells[0].Text);
                this.Session[Global.ID_MATERIA_SELECCIONADA] = id_materia;
                Response.Redirect("ElegirComision.aspx");
            }
        }
    }//end class
}