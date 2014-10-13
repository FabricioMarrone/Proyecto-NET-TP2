using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        private usuario _usuario;
        public usuario Usuario
        {
            get { return _usuario; }
            set { this._usuario = value; }
        }

        public formMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            this.showLogin();
        }

        private void showLogin() 
        {
            Usuario = null;

            formLogin appLogin = new formLogin(this);
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                //Login exitoso.Dependiendo del tipo de usuario, derivamos a un menu u a otro.
                PersonaLogic perLogic = new PersonaLogic();
                persona per = perLogic.GetOne(Usuario.id_persona);

                if (per == null)
                {
                    MessageBox.Show(this.Text, "ERROR: El usuario no posee un registro persona",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (per.tipo_persona)
                {
                    case (int)persona.tipo.Alumno:
                        MenuAlumno menu = new MenuAlumno(per);
                        menu.ShowDialog();
                        break;
                    case (int)persona.tipo.Admin:

                        break;
                    case (int)persona.tipo.Profesor:

                        break;
                }//end switch

            }//end else login ok
        }
    }//end class
}
