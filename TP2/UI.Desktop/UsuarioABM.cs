using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioABM : ApplicationForm
    {
        public usuario UsuarioActual;

        public UsuarioABM()
        {
            InitializeComponent();
        }

        public UsuarioABM(ModoForm modo): this()
        {
            this.Modo = modo;
            this.UsuarioActual = new usuario();
        }

        public UsuarioABM(int id, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic oUsuarioLog = new UsuarioLogic();
            this.UsuarioActual = oUsuarioLog.GetOne(id);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.id_usuario.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.habilitado;
            this.txtNombre.Text = this.UsuarioActual.nombre;
            this.txtApellido.Text = this.UsuarioActual.apellido;
            this.txtEmail.Text = this.UsuarioActual.email;
            this.txtUsuario.Text = this.UsuarioActual.nombre_usuario;
            this.txtClave.Text = this.UsuarioActual.clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.clave;

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtID.Enabled = false;
                    this.chkHabilitado.Enabled = false;
                    this.txtNombre.Enabled = false;
                    this.txtApellido.Enabled = false;
                    this.txtEmail.Enabled = false;
                    this.txtUsuario.Enabled = false;
                    this.txtClave.Enabled = false;
                    this.txtConfirmarClave.Enabled = false;
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    this.txtID.Enabled = false;
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        public override bool Validar()
        {
            //llamar a funciones de la capa Util, valir cadenas.
            if (this.txtNombre.Text.Trim() == "" || this.txtApellido.Text.Trim() == "" 
                || this.txtEmail.Text.Trim() == "" || this.txtUsuario.Text.Trim() == "" 
                || this.txtClave.Text.Trim() == "" || this.txtConfirmarClave.Text.Trim() == "")
            {
                this.Notificar("Campos Incompletos", "Todos los campos deben ser completados.", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!(this.txtClave.Text.Equals(this.txtConfirmarClave.Text)))
            {
                this.Notificar("Clave Incorrecta", "La Claves y Conformacion Clave deben ser iguales.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (this.txtClave.Text.Length < 8)
                {
                    this.Notificar("Clave Incorrecta", "La Claves debe tener al menos 8 caracteres.", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic oUsuarioLog = new UsuarioLogic();
            oUsuarioLog.Save(this.UsuarioActual, this.Modo.ToString());    
        }

        public override void MapearADatos()
        {
            this.UsuarioActual.nombre = this.txtNombre.Text;
            this.UsuarioActual.apellido = this.txtApellido.Text;
            this.UsuarioActual.nombre_usuario = this.txtUsuario.Text;
            this.UsuarioActual.email = this.txtEmail.Text;
            this.UsuarioActual.clave = this.txtClave.Text;
            this.UsuarioActual.habilitado = this.chkHabilitado.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
