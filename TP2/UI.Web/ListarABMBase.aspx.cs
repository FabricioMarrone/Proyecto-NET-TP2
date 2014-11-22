using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public abstract partial class ListarABMBase : System.Web.UI.Page
    {

        #region Propiedades y variables instacion
        public enum FormModes { Alta, Baja, Modificacion }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected int SelectedID
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
                    this.CargarExpresionesRegulares();
                }
                else
                {
                    this.Response.Redirect("Home.aspx");
                }
            }
        }

        protected void LoadForm(int id)
        {// Misma Funcionalidad de Mapear a Datos
            this.ClearForm();
            
            this.mapearDeDatos(id);

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

        #region metodos para Implementar en clase derivada
        protected abstract void LoadGrid();

        protected abstract void mapearDeDatos(int id);

        protected abstract void CargarExpresionesRegulares();

        protected abstract void ClearForm();

        protected abstract void EnableForm(bool enable);

        protected abstract void GuardarCambios();

        #endregion

        #region metodos manejadores de eventos.

        //protected void NuevoLinkButton_Click(object sender, EventArgs e)
        //{
        //    this.formPanel.Visible = true;
        //    this.ClearForm();
        //    this.FormMode = FormModes.Alta;
        //    this.EnableForm(true);
        //}

        //protected void EditarLinkButton_Click(object sender, EventArgs e)
        //{
        //    if (this.isEntitySelected)// Valido que haya alguna fila seleccionada
        //    {
        //        this.formPanel.Visible = true;
        //        this.FormMode = FormModes.Modificacion;
        //        this.LoadForm(this.SelectedID);
        //        this.EnableForm(true);
        //    }
        //}

        //protected void EliminarLinkButton_Click(object sender, EventArgs e)
        //{
        //    if (this.isEntitySelected)
        //    {
        //        this.formPanel.Visible = true;
        //        this.FormMode = FormModes.Baja;
        //        this.LoadForm(this.SelectedID);
        //    }
        //}

        //protected void lbAceptar_Click(object sender, EventArgs e)
        //{
        //    if (Page.IsValid)
        //    {
        //        this.GuardarCambios();
        //        this.formPanel.Visible = false;
        //    }
        //}

        //protected void lbCancelar_Click(object sender, EventArgs e)
        //{
        //    this.formPanel.Visible = false;
        //    this.LoadGrid();
        //}
        #endregion

    }
}