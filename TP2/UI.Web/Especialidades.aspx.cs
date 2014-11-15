using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Especialidades : System.Web.UI.Page
    {
        #region Propiedades y variables instacion
        private EspecialidadLogic _espLogic;

        private EspecialidadLogic EspLogic
        {
            get
            {
                if (this._espLogic == null) this._espLogic = new EspecialidadLogic();
                return this._espLogic;
            }
        }

        public enum FormModes { Alta, Baja, Modificacion }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        public especialidade entity { get; set; }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null) return (int)this.ViewState["SelectedID"];
                else return 0;
            }
            set { this.ViewState["SelectedID"] = value; }
        }

        public bool isEntitySelected
        {
            get { return (this.SelectedID != 0); }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                persona personaActual = (persona)this.Session[Global.PERSONA_ACTUAL];
                if (personaActual != null && personaActual.tipo_persona == (int)persona.tipo.Admin)
                {
                    this.LoadGrid();
                }
                this.CargarExpresionesRegulares();
            }
        }

        private void LoadGrid()
        {
            try
            {
                this.gvEspecialidades.DataSource = this.EspLogic.GetAll();
                this.gvEspecialidades.DataBind();
                this.gvEspecialidades.SelectedIndex = -1;
            }
            catch (Exception ex) // Habria que declrar exception Propia que indique que la lista esta vacia.
            {
                this.gridPanel.Visible = false;

                this.messageArea.ForeColor = System.Drawing.Color.Red;
                this.messageArea.Text = "No existen Especialidades para mostrar. " + ex.Message;
            }
        }

        private void LoadForm(int id)
        {// Misma Funcionalidad de Mapear a Datos
            this.ClearForm();

            this.entity = this.EspLogic.GetOne(id);
            this.txtId.Text = this.entity.id_especialidad.ToString();
            this.txtEspecialidad.Text = this.entity.desc_especialidad;

            switch (this.FormMode)
            {
                case FormModes.Alta:
                    break;
                case FormModes.Baja:
                    this.EnableForm(false);
                    break;
                case FormModes.Modificacion:
                    break;
            }
        }

        private void LoadEntity(especialidade especialidad)
        {// Misma Funcionalidad de Mapear De Datos
            especialidad.desc_especialidad = this.txtEspecialidad.Text;
        }

        private void CargarExpresionesRegulares()
        {
            this.revEspecialidad.ValidationExpression = Util.Validador.ExpreCadenaSoloTexto;
        }

        private void ClearForm()
        {
            this.txtId.Text = String.Empty;
            this.txtEspecialidad.Text = String.Empty;
        }

        private void EnableForm(bool enable)
        {
            this.txtEspecialidad.Enabled = enable;
            this.txtId.Enabled = enable;
        }

        private void GuardarCambios()
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.entity = new especialidade();
                    this.LoadEntity(this.entity);
                    this.EspLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.EspLogic.Delete(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.entity = new especialidade();
                    this.entity.id_especialidad = this.SelectedID;
                    this.LoadEntity(this.entity);
                    this.EspLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
            }
            // Al final se seatea el SelectedID en 0 para que no mantenga el valor
            // de una anterior seleccion.
            this.SelectedID = 0;
        }

        #region Manejadores de eventos
        protected void gvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvEspecialidades.SelectedValue;
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.ClearForm();
            this.FormMode = FormModes.Alta;
            this.EnableForm(true);
        }

        protected void EditarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)// Valido que haya alguna fila seleccionada
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void lbAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.GuardarCambios();
                this.formPanel.Visible = false;
            }
        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.LoadGrid();
        }
        #endregion
    }
}