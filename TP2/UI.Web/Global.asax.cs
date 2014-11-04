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


        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            this.Session[USUARIO_ACTUAL] = null;
            this.Session[PERSONA_ACTUAL] = null;
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