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
            
            if (IsPostBack)
            {
                if (this.Session[Global.USUARIO_ACTUAL] != null)
                {
                    this.occultLogin();
                }
                else 
                {
                    this.showLogin();
                }
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Se limpia el area de mensajes.
            this.messageLogin.Text = "";

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

                    this.Session[Global.USUARIO_ACTUAL] = usr;
                    this.Session[Global.PERSONA_ACTUAL] = per;

                    Site master = (Site)this.Master;
                    master.showMenu(per.tipo_persona);

                    this.occultLogin();
                }
                else
                {
                    //Contraseña incorrecta
                    this.messageLoginPanel.Visible = true;
                    this.messageLogin.Text = "La contraseña es incorrecta.";

                    //Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('La contraseña es incorrecta.')</SCRIPT>");
                    this.txtContraseña.Text = "";
                }
            }
            else
            {
                //El usuario no existe
                this.messageLoginPanel.Visible = true;
                this.messageLogin.Text = "El usuario no existe.";

                //Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('El usuario no existe.')</SCRIPT>");
                this.txtContraseña.Text = "";
            }
        }//end boton iniciar sesion

        
        public void showLogin() 
        {
            LinkButton linkIniciarSesion = (LinkButton)FindControlRecursive(Master, "linkMenuOption0");
            linkIniciarSesion.Text = "Iniciar sesión";

            this.loginPanel.Visible = true;

            //this.lblUsuario.Visible = true;
            //this.lblPass.Visible = true;
            //this.txtUsuario.Visible = true;
            //this.txtContraseña.Visible = true;
            //this.btnIniciarSesion.Visible = true;
            //this.lblMsg.Text = "Ingrese sus datos para comenzar";
        }

        public void occultLogin() 
        {
            LinkButton linkIniciarSesion = (LinkButton)FindControlRecursive(Master, "linkMenuOption0");
            linkIniciarSesion.Text = "Cerrar sesión";

            this.loginPanel.Visible = false;
            //this.lblUsuario.Visible = false;
            //this.lblPass.Visible = false;
            //this.txtUsuario.Visible = false;
            //this.txtContraseña.Visible = false;
            //this.btnIniciarSesion.Visible = false;


            persona per = (persona)this.Session[Global.PERSONA_ACTUAL];
            this.lblMsg.Text = "Bienvenido " + per.nombre + " " + per.apellido + "!";
            
            //String.Format("Bienvenido {0} {1}!", user.nombre, user.apellido)
        }

        public static Control FindControlRecursive(Control control, string id)
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