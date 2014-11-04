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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton linkIniciarSesion = (LinkButton)FindControlRecursive(Master, "linkMenuOption0");
            //if (!IsPostBack)
            //{
            //    linkIniciarSesion.Text = "Iniciar sesion";

            //    LinkButton linkMenuOption1 = (LinkButton)FindControlRecursive(Master, "linkMenuOption1");
            //    LinkButton linkMenuOption2 = (LinkButton)FindControlRecursive(Master, "linkMenuOption2");
            //    LinkButton linkMenuOption3 = (LinkButton)FindControlRecursive(Master, "linkMenuOption3");
            //    linkMenuOption1.Visible = false;
            //    linkMenuOption2.Visible = false;
            //    linkMenuOption3.Visible = false;
                
            //}
            //else 
            //{
            //    if (this.Session[Global.USUARIO_ACTUAL] != null) linkIniciarSesion.Text = "Cerrar sesión";
            //}
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Obtenemos datos del form
            string usu = this.txtUsuario.Text;
            string pass = this.txtContraseña.Text;

            //Obtenemos el usuario y verificamos contraseña
            UsuarioLogic logic = new UsuarioLogic();
            usuario usr = logic.getByName(usu);

            if (usr != null)
            {
                //Verificamos contraseña
                if (usr.clave == this.txtContraseña.Text)
                {
                    //Loggin exitoso
                    PersonaLogic perLogic = new PersonaLogic();
                    persona per = perLogic.GetOne(usr.id_persona);

                    if (per == null)
                    {
                        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('El usuario no posee un registro persona.')</SCRIPT>");
                        return;
                    }

                    LinkButton linkIniciarSesion = (LinkButton)FindControlRecursive(Master, "linkMenuOption0");
                    linkIniciarSesion.Text = "Cerrar sesion";

                    this.showMenu(per.tipo_persona);
                    
                    this.Session[Global.USUARIO_ACTUAL] = usr;
                    this.Session[Global.PERSONA_ACTUAL] = per;
                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Usuario OK')</SCRIPT>");
                }
                else
                {
                    //Contraseña incorrecta
                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('La contraseña es incorrecta.')</SCRIPT>");
                    this.txtContraseña.Text = "";
                }
            }
            else
            {
                //El usuario no existe
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('El usuario no existe.')</SCRIPT>");
                this.txtContraseña.Text = "";
            }
        }//end boton iniciar sesion

        public void showMenu(int tipo) 
        {
            LinkButton linkMenuOption1 = (LinkButton)FindControlRecursive(Master, "linkMenuOption1");
            LinkButton linkMenuOption2 = (LinkButton)FindControlRecursive(Master, "linkMenuOption2");
            LinkButton linkMenuOption3 = (LinkButton)FindControlRecursive(Master, "linkMenuOption3");

            switch (tipo)
            {
                case (int)persona.tipo.Alumno:
                    linkMenuOption1.Text = "Modificar datos";
                    linkMenuOption2.Text = "Estado academico";
                    linkMenuOption3.Text = "Inscripcion a materia";
                    linkMenuOption1.Visible = true;
                    linkMenuOption2.Visible = true;
                    linkMenuOption3.Visible = true;
                    break;
                case (int)persona.tipo.Admin:
                    
                    break;
                case (int)persona.tipo.Profesor:
                    
                    break;
            }//end switch
        }

        public void occultMenu() 
        {
            LinkButton linkMenuOption1 = (LinkButton)FindControlRecursive(Master, "linkMenuOption1");
            LinkButton linkMenuOption2 = (LinkButton)FindControlRecursive(Master, "linkMenuOption2");
            LinkButton linkMenuOption3 = (LinkButton)FindControlRecursive(Master, "linkMenuOption3");
            linkMenuOption1.Visible = false;
            linkMenuOption2.Visible = false;
            linkMenuOption3.Visible = false;
        }

        private static Control FindControlRecursive(Control control, string id)
        {
            if (control.ID == id)
            {
                return control;
            }

            foreach (Control ctrl in control.Controls)
            {
                var foundCtrl = FindControlRecursive(ctrl, id);
                if (foundCtrl != null)
                {
                    return foundCtrl;
                }
            }
            return null;
        }
    }//end class
}