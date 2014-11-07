using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Business.Entities;

namespace UI.Web
{
    public class Global : System.Web.HttpApplication
    {
        public static string USUARIO_ACTUAL = "Usuario";
        public static string PERSONA_ACTUAL = "Persona";
        public static string INSCRIPCION_ACTUAL = "InscripcionAlumno";
        public static string ID_MATERIA_SELECCIONADA = "id_materia";

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            this.Session[USUARIO_ACTUAL] = null;
            this.Session[PERSONA_ACTUAL] = null;
            this.Session[INSCRIPCION_ACTUAL] = null;
            this.Session[ID_MATERIA_SELECCIONADA] = null;
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }//end class
}