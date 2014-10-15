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
    public partial class formLogin : Form
    {
        private formMain main;

        public formLogin(formMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Obtenemos el usuario y verificamos contraseña
            UsuarioLogic logic= new UsuarioLogic();
            usuario usr = logic.getByName(this.txtUsuario.Text);

            if (usr != null)
            {
                //Verificamos contraseña
                if (usr.clave == this.txtPass.Text)
                {
                    //Loggin exitoso
                    main.Usuario = usr;
                    this.DialogResult = DialogResult.OK;
                }
                else { 
                    //Contraseña incorrecta
                    MessageBox.Show("Contraseña incorrecta.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPass.Text = "";
                }
            }
            else { 
                //El usuario no existe
                MessageBox.Show("El nombre de usuario no es válido.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }//fin brn ingresar

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria.", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


    }//end class
}
