using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkMenuOption0_Click(object sender, EventArgs e)
        {
            if (this.Session[Global.USUARIO_ACTUAL] == null)
            {
                //No hay sesion iniciada
                Response.Redirect("Home.aspx");
            }
            else 
            {
                //Hay sesion iniciada y se desea "cerrar la sesion".
                this.Session[Global.USUARIO_ACTUAL] = null;
                this.Session[Global.PERSONA_ACTUAL] = null;
                this.linkMenuOption0.Text = "Iniciar sesion";
                this.linkMenuOption1.Visible = false;
                this.linkMenuOption2.Visible = false;
                this.linkMenuOption3.Visible = false;
                Response.Redirect("Home.aspx");
            }
        }
    }//end class
}