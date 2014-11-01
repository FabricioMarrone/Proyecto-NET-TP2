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
using Util;

namespace UI.Desktop
{
    public partial class UsuarioABM : ApplicationForm
    {
        public usuario UsuarioActual;

        public UsuarioABM()
        {
            InitializeComponent();

            PersonaLogic logic = new PersonaLogic();
            this.cbPersonas.DataSource = PersonaLogic.getPersonasExtended(logic.GetAll());
            this.cbPersonas.ValueMember = "id_persona";
            this.cbPersonas.DisplayMember = "desc";
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
            this.cbPersonas.SelectedValue = this.UsuarioActual.id_persona;

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
                    this.cbPersonas.Enabled = false;
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
            if (this.txtNombre.Text.Trim() == "" || this.txtApellido.Text.Trim() == "" 
                || this.txtEmail.Text.Trim() == "" || this.txtUsuario.Text.Trim() == "" 
                || this.txtClave.Text.Trim() == "" || this.txtConfirmarClave.Text.Trim() == "")
            {
                this.Notificar("Campos Incompletos", "Todos los campos deben ser completados.", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ( !(Validador.ValidarCadenaSoloTexto(this.txtNombre.Text)) )
            {
                this.Notificar("Campos Invalido", "El campo Nombre es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ( !(Validador.ValidarCadenaSoloTexto(this.txtApellido.Text) ))
            {
                this.Notificar("Campos Invalido", "El campo Apellido es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if ( !(Validador.ValidarEMail(this.txtEmail.Text)) )
            {
                this.Notificar("Campos Invalido", "El campo Email es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if ( !(Validador.ValidarNombreUsuario(this.txtUsuario.Text)) )
            {
                this.Notificar("Campos Invalido", "El campo Usuario es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ( !(Validador.ValidarClave(this.txtClave.Text,this.txtConfirmarClave.Text)))
            {
                this.Notificar("Campos Invalido", "El campo Clave es Invalido.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
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
            this.UsuarioActual.id_persona = (int)this.cbPersonas.SelectedValue;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.UsuarioActual != null) 
            {
                int id_persona = (int)this.cbPersonas.SelectedValue;
                PersonaLogic logic = new PersonaLogic();
                persona p = logic.GetOne(id_persona);
                this.txtNombre.Text = p.nombre;
                this.txtApellido.Text = p.apellido;
                this.txtEmail.Text = p.email;
            }            
        }

    }//end class
}
