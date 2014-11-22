using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Web
{
    public partial class Comisiones : ListarABMBase
    {

        #region Prop y Vars
        private ComisionLogic _comLogic;

        private ComisionLogic ComLogic
        {
            get
            {
                if (this._comLogic == null) this._comLogic = new ComisionLogic();
                return this._comLogic;
            }
        }

        public comisione entity { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.Page_Load(sender,e);
                this.CargarDropDownListEspecialidad();
            }
        }


        #region metodos para Implementar en clase derivada

        protected override void LoadGrid()
        {
            try
            {
                this.gvListar.DataSource = ComisionLogic.getComisionesExtended(this.ComLogic.GetAll());
                this.gvListar.DataBind();
                this.gvListar.SelectedIndex = -1;
            }
            catch (Exception ex) // Habria que declrar exception Propia que indique que la lista esta vacia.
            {
                this.gridPanel.Visible = false;

                this.messageArea.ForeColor = System.Drawing.Color.Red;
                this.messageArea.Text = "No existen Comisiones para mostrar. " + ex.Message;
            }
        }

        protected override void mapearDeDatos(int id)
        {
            comisione com = this.ComLogic.GetOne(id);
            this.IdComisionTextBox.Text = com.id_comision.ToString();
            this.mtvComision.Text = com.desc_comision;
            this.mtvAnioEspecialidad.Text = com.anio_especialidad.ToString();

            PlanLogic planLogic = new PlanLogic();
            plane p = planLogic.GetOne(com.id_plan);
            this.ddlEspecialidad.SelectedValue = p.id_especialidad.ToString();

            this.CargarDropDownListPlan(p.id_especialidad);
            this.ddlPlan.SelectedValue = com.id_plan.ToString();
        }

        private void CargarDropDownListEspecialidad()
        {
            EspecialidadLogic espLogic = new EspecialidadLogic();
            List<especialidade> especialidades = espLogic.GetAll();
            if (especialidades.Count > 0)
            {
                this.ddlEspecialidad.DataSource = especialidades;
                this.ddlEspecialidad.DataValueField = "id_especialidad";
                this.ddlEspecialidad.DataTextField = "desc_especialidad";
                this.ddlEspecialidad.DataBind();
            }
            //this.ddlPlan.Enabled = false;
            CargarDropDownListPlan(Int32.Parse(this.ddlEspecialidad.SelectedValue));
        }

        private void CargarDropDownListPlan(int idEspecialidad)
        {
            PlanLogic planLogic = new PlanLogic();
            this.ddlPlan.DataSource = planLogic.GetPlanesDeEspecialidad(idEspecialidad);
            // Validar que la lista que devuelva no este vacia.
            // Si esta vacia deshabilitar el boton de aceptar.
            this.ddlPlan.DataValueField = "id_plan";
            this.ddlPlan.DataTextField = "desc_plan";

            this.ddlPlan.Enabled = true;
            this.ddlPlan.DataBind();
        }


        protected void LoadEntity(comisione entity)
        {
            entity.desc_comision = this.mtvComision.Text;
            entity.anio_especialidad = Int32.Parse(this.mtvAnioEspecialidad.Text);
            entity.id_plan = Int32.Parse(this.ddlPlan.SelectedValue);
        }

        protected override void CargarExpresionesRegulares()
        {
            this.mtvComision.ValidationExpression = Validador.ExpreCadenaTextoYNumeros;
            this.mtvAnioEspecialidad.ValidationExpression = Validador.ExpreAnioEspecialidad;
        }

        protected override void ClearForm()
        {
            this.IdComisionTextBox.Text = string.Empty;
            this.mtvComision.Text = string.Empty;
            this.mtvAnioEspecialidad.Text = string.Empty;
            this.ddlEspecialidad.ClearSelection();
            this.ddlPlan.ClearSelection();
        }

        protected override void EnableForm(bool enable)
        {
            this.IdComisionTextBox.Enabled = enable;
            this.mtvComision.Enabled = enable;
            this.mtvAnioEspecialidad.Enabled = enable;
            this.ddlEspecialidad.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        protected override void GuardarCambios()
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.entity = new comisione();
                    this.LoadEntity(this.entity);
                    this.ComLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.ComLogic.Delete(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.entity = new comisione();
                    this.entity.id_comision = this.SelectedID;
                    this.LoadEntity(this.entity);
                    this.ComLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
            }
            // Al final se seatea el SelectedID en 0 para que no mantenga el valor
            // de una anterior seleccion.
            this.SelectedID = 0;
        }
        #endregion


        #region manejadores de eventos.
        protected void gvListar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvListar.SelectedValue;
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarDropDownListPlan(Int32.Parse(this.ddlEspecialidad.SelectedValue));
        }

        protected void NuevoLinkButton_Click1(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.ClearForm();
            this.FormMode = FormModes.Alta;
            this.EnableForm(true);
        }

        protected void EditarLinkButton_Click1(object sender, EventArgs e)
        {
            if (this.isEntitySelected)// Valido que haya alguna fila seleccionada
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
            }
        }

        protected void EliminarLinkButton_Click1(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void AceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.GuardarCambios();
                this.formPanel.Visible = false;
            }
        }

        protected void CancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.LoadGrid();
            this.SelectedID = 0;
        }
        #endregion
    }
}