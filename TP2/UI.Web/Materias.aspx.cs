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
    public partial class Materias : ListarABMBase
    {

        #region Prop y Vars
        private MateriaLogic _matLogic;

        private MateriaLogic MatLogic
        {
            get
            {
                if (this._matLogic == null) this._matLogic = new MateriaLogic();
                return this._matLogic;
            }
        }

        public materia entity { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                base.Page_Load(sender, e);
                this.CargarDropDownListEspecialidad();   
            }
        }

        #region metodos para Implementar en clase derivada

        protected override void LoadGrid()
        {
            try
            {
                this.gvListar.DataSource = MateriaLogic.getMateriasExtended(this.MatLogic.GetAll());
                this.gvListar.DataBind();
                this.gvListar.SelectedIndex = -1;
            }
            catch (Exception ex) // Habria que declrar exception Propia que indique que la lista esta vacia.
            {
                this.gridPanel.Visible = false;

                this.messageArea.ForeColor = System.Drawing.Color.Red;
                this.messageArea.Text = "No existen Materias para mostrar. " + ex.Message;
            }
        }

        protected override void mapearDeDatos(int id)
        {
            materia mat = this.MatLogic.GetOne(id);
            this.IdMateriaTextBox.Text = mat.id_materia.ToString();
            this.DescripcionTextBox.Text = mat.desc_materia ;
            this.txtHsSemanales.Text = mat.hs_semanales.ToString();
            this.txtHsTotales.Text = mat.hs_totales.ToString();


            PlanLogic planLogic = new PlanLogic();
            plane p = planLogic.GetOne(mat.id_plan);
            this.ddlEspecialidad.SelectedValue = p.id_especialidad.ToString();

            this.CargarDropDownListPlan(p.id_especialidad);
            this.ddlPlan.SelectedValue = mat.id_plan.ToString();
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
            this.ddlPlan.Enabled = false;
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


        protected void LoadEntity(materia entity)
        {
            entity.desc_materia = this.DescripcionTextBox.Text;
            entity.hs_semanales = Int32.Parse(this.txtHsSemanales.Text);
            entity.hs_totales = Int32.Parse(this.txtHsTotales.Text);
            entity.id_plan = Int32.Parse(this.ddlPlan.SelectedValue);
        }

        protected override void CargarExpresionesRegulares()
        {
            this.revDescripcion.ValidationExpression = Validador.ExpreCadenaSoloTexto;
            this.revHsSemanales.ValidationExpression = Validador.ExpreEnteroPositivo;
            this.revHsTotales.ValidationExpression = Validador.ExpreEnteroPositivo;
        }

        protected override void ClearForm()
        {
            this.IdMateriaTextBox.Text = string.Empty;
            this.DescripcionTextBox.Text = string.Empty;
            this.txtHsSemanales.Text = string.Empty;
            this.txtHsTotales.Text = string.Empty;
            //this.ddlEspecialidad.SelectedValue = mat. .ToString();
            this.ddlPlan.ClearSelection();
        }

        protected override void EnableForm(bool enable)
        {
            this.IdMateriaTextBox.Enabled = enable;
            this.DescripcionTextBox.Enabled = enable;
            this.txtHsSemanales.Enabled = enable;
            this.txtHsTotales.Enabled = enable;
            this.ddlEspecialidad.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        protected override void GuardarCambios()
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.entity = new materia();
                    this.LoadEntity(this.entity);
                    this.MatLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.MatLogic.Delete(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.entity = new materia();
                    this.entity.id_materia = this.SelectedID;
                    this.LoadEntity(this.entity);
                    this.MatLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
            }
            // Al final se seatea el SelectedID en 0 para que no mantenga el valor
            // de una anterior seleccion.
            this.SelectedID = 0;
        }
        #endregion


#region manejadores eventos.
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