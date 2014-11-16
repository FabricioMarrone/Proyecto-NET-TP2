using System;
using System.Collections;
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
    public partial class Planes : ListarABMBase
    {
        #region Prop y Vars
        private PlanLogic _planLogic;

        private PlanLogic PlanLogic
        {
            get
            {
                if (this._planLogic == null) this._planLogic = new PlanLogic();
                return this._planLogic;
            }
        }

        public plane entity { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e) 
        {
            base.Page_Load(sender, e);
            this.LoadDropDownList();
        }

        #region metodos para Implementar en clase derivada

        protected override void LoadGrid() 
        {
            try
            {
                this.gvListar.DataSource = PlanLogic.getPlanesExtended(this.PlanLogic.GetAll());
                this.gvListar.DataBind();
                this.gvListar.SelectedIndex = -1;
            }
            catch (Exception ex) // Habria que declrar exception Propia que indique que la lista esta vacia.
            {
                this.gridPanel.Visible = false;

                this.messageArea.ForeColor = System.Drawing.Color.Red;
                this.messageArea.Text = "No existen Especialidades para mostrar. " + ex.Message;
            }            
        }

        protected override void mapearDeDatos(int id) 
        {
            plane plan = this.PlanLogic.GetOne(id);
            this.IdPlanTextBox.Text = plan.id_plan.ToString();
            this.PlanTextBox.Text = plan.desc_plan;
            this.ddlEspecialidad.SelectedValue = plan.id_especialidad.ToString();
        }

        protected void LoadDropDownList() 
        {
            EspecialidadLogic espLogic = new EspecialidadLogic();
            List<especialidade> especialidades = espLogic.GetAll();
            if ( especialidades.Count > 0 )
            {
                this.ddlEspecialidad.DataSource = especialidades;
                this.ddlEspecialidad.DataValueField = "id_especialidad";
                this.ddlEspecialidad.DataTextField = "desc_especialidad";
                this.ddlEspecialidad.DataBind();
                this.ddlEspecialidad.Enabled = true;
            }
        }

        protected void LoadEntity(plane entity) 
        {
            entity.desc_plan = this.PlanTextBox.Text;
            entity.id_especialidad = Int32.Parse(ddlEspecialidad.SelectedValue);
        }

        protected override void CargarExpresionesRegulares() 
        {
            this.revPlan.ValidationExpression = Validador.ExpreCadenaTextoYNumeros;
        }

        protected override void ClearForm() 
        {
            this.IdPlanTextBox.Text = string.Empty;
            this.PlanTextBox.Text = string.Empty;
            this.ddlEspecialidad.ClearSelection();
        }

        protected override void EnableForm(bool enable) 
        {
            this.IdPlanTextBox.Enabled = enable;
            this.PlanTextBox.Enabled = enable;
            this.ddlEspecialidad.Enabled = enable;
        }

        protected override void GuardarCambios() 
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.entity = new plane();
                    this.LoadEntity(this.entity);
                    this.PlanLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.PlanLogic.Delete(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.entity = new plane();
                    this.entity.id_plan = this.SelectedID;
                    this.LoadEntity(this.entity);
                    this.PlanLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
            }
            // Al final se seatea el SelectedID en 0 para que no mantenga el valor
            // de una anterior seleccion.
            this.SelectedID = 0;
        }
        #endregion

        #region manejadores de eventos
        protected void gvListar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvListar.SelectedValue;
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