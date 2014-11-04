using System;
using System.Collections.Generic;
using System.Linq;
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
    }//end class
}