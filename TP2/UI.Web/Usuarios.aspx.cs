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
    public partial class Usuarios : System.Web.UI.Page
    {
        private UsuarioLogic _logic;
        private UsuarioLogic logic {
            get {
                if (_logic == null) _logic = new UsuarioLogic();
                return _logic;
            }
        }

        public enum FormModes { 
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private usuario entity
        {
            get;
            set;
        }

        private int SelectedID 
        {
            get {
                if (this.ViewState["SelectedID"] != null) return (int)this.ViewState["SelectedID"];
                else return 0;
            }
            set {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool isEntitySelected {
            get { return (this.SelectedID != 0); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                persona personaActual = (persona)this.Session[Global.PERSONA_ACTUAL];
                if (personaActual != null && personaActual.tipo_persona == (int)persona.tipo.Admin)
                {
                    this.loadGrid();
                }
                else
                {
                    Response.Redirect("~/Home.aspx");
                }
            }
            else { 
                //...
            }
        }

        private void loadGrid() {
            this.gridView.DataSource = this.logic.GetAll();
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void loadForm(int id) {
            this.entity = this.logic.GetOne(id);
            this.nombreTextBox.Text = this.entity.nombre;
            this.apellidoTextBox.Text = this.entity.apellido;
            this.emailTextBox.Text = this.entity.email;
            this.habilitadoCheckBox.Checked = this.entity.habilitado;
            this.nombreUsuarioTextBox.Text = this.entity.nombre_usuario;
        }

        private void loadEntity(usuario usuario) {
            usuario.nombre = this.nombreTextBox.Text;
            usuario.apellido = this.apellidoTextBox.Text;
            usuario.email = this.emailTextBox.Text;
            usuario.nombre_usuario = this.nombreUsuarioTextBox.Text;
            usuario.clave = this.claveTextBox.Text;
            usuario.habilitado = this.habilitadoCheckBox.Checked;
        }

        private void saveEntity(usuario usuario) {
            this.logic.Save(usuario, this.FormMode.ToString());
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected) {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.enableForm(true);
                this.loadForm(this.SelectedID);
            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        this.deleteEntity(this.SelectedID);
                        this.loadGrid();
                        break;

                    case FormModes.Modificacion:
                        this.entity = new usuario();
                        this.entity.id_usuario = this.SelectedID;
                        this.loadEntity(this.entity);
                        this.saveEntity(this.entity);
                        this.loadGrid();
                        break;

                    case FormModes.Alta:
                        this.entity = new usuario();
                        this.loadEntity(this.entity);
                        this.saveEntity(this.entity);
                        this.loadGrid();
                        break;
                }//end switch
                this.formPanel.Visible = false;
            }
            
        }

        private void enableForm(bool enable) {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Enabled = enable;
            this.claveLabel.Enabled = enable;
            this.repetirClaveTextBox.Enabled = enable;
            this.repetirClaveLabel.Enabled = enable;

            this.valReqNombre.Enabled = enable;
            this.valReqApellido.Enabled = enable;
            this.valReqNombreUsuario.Enabled = enable;
            this.CompareValidatorClave.Enabled = enable;
            this.ValidationSummary.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected) {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.enableForm(false);
                this.loadForm(this.SelectedID);
            }
        }

        private void deleteEntity(int id) {
            this.logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.clearForm();
            this.enableForm(true);
        }

        private void clearForm() {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.loadGrid();
        }
    }//end class
}