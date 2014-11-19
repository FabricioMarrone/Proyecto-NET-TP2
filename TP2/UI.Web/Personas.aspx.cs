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
    public partial class Personas : ListarABMBase
    {
        #region Prop y Vars
        private PersonaLogic _personaLogic;

        private PersonaLogic PersonaLogic
        {
            get
            {
                if (this._personaLogic == null) this._personaLogic = new PersonaLogic();
                return this._personaLogic;
            }
        }

        public persona entity { get; set; }

        #endregion


        protected void Page_Load(object sender, EventArgs e) 
        {
            if ( !IsPostBack )
            {
                base.Page_Load(sender,e);
                this.CargarDropDownListEspecialidades();
                this.CargarDropDownListTipoPersona();
            }
        }

        private void CargarDropDownListTipoPersona()
        {
            this.ddlTipoPersona.DataSource = Enum.GetValues(typeof(persona.tipo));
            this.ddlTipoPersona.DataBind();
        }

        #region metodos para Implementar en clase derivada

        protected override void LoadGrid()
        {
            try
            {
                this.gvListar.DataSource = PersonaLogic.getPersonasExtended(this.PersonaLogic.GetAll());
                this.gvListar.DataBind();
                this.gvListar.SelectedIndex = -1;
            }
            catch (Exception ex) // Habria que declrar exception Propia que indique que la lista esta vacia.
            {
                this.gridPanel.Visible = false;

                this.messageArea.ForeColor = System.Drawing.Color.Red;
                this.messageArea.Text = "No existen Personas para mostrar. " + ex.Message;
            }
        }

        protected override void mapearDeDatos(int id)
        {
            persona per = this.PersonaLogic.GetOne(id);
            this.IdPersonaTextBox.Text = per.id_persona.ToString();
            this.mtvLegajo.Text = per.legajo.ToString();
            this.mtvApellido.Text = per.apellido;
            this.mtvNombre.Text = per.nombre;
            this.mtvDireccion.Text = per.direccion;
            this.mtvEmail.Text = per.email;
            this.mtvFechaNac.Text = per.fecha_nac.ToShortDateString() ;

            this.ddlTipoPersona.SelectedIndex = per.tipo_persona;

            PlanLogic planLogic = new PlanLogic();
            plane plan = planLogic.GetOne(per.id_plan);
            this.ddlEspecialidad.SelectedValue = plan.id_especialidad.ToString();

            this.CargarDropDownListPlan(plan.id_especialidad);
            this.ddlPlan.SelectedValue = per.id_plan.ToString();
        }

        protected void CargarDropDownListEspecialidades()
        {
            EspecialidadLogic espLogic = new EspecialidadLogic();
            List<especialidade> especialidades = espLogic.GetAll();
            if (especialidades.Count > 0)
            {
                this.ddlEspecialidad.DataSource = especialidades;
                this.ddlEspecialidad.DataValueField = "id_especialidad";
                this.ddlEspecialidad.DataTextField = "desc_especialidad";
                this.ddlEspecialidad.DataBind();
                this.ddlEspecialidad.Enabled = true;
            }
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

        protected void LoadEntity(persona entity)
        {
            entity.legajo = Int32.Parse(this.mtvLegajo.Text);
            entity.apellido = this.mtvApellido.Text;
            entity.nombre = this.mtvNombre.Text;
            entity.direccion = this.mtvDireccion.Text;
            entity.email = this.mtvEmail.Text; 
            entity.fecha_nac = DateTime.Parse(this.mtvFechaNac.Text);
            entity.tipo_persona = this.ddlTipoPersona.SelectedIndex;
            entity.id_plan = Int32.Parse(ddlPlan.SelectedValue);
        }

        protected override void CargarExpresionesRegulares()
        {
            this.mtvLegajo.ValidationExpression = Validador.ExpreLegajo;
            this.mtvApellido.ValidationExpression = Validador.ExpreCadenaSoloTexto;
            this.mtvNombre.ValidationExpression = Validador.ExpreCadenaSoloTexto;
            this.mtvDireccion.ValidationExpression = Validador.ExpreDireccion;
            this.mtvEmail.ValidationExpression = Validador.ExpreEMail;
            this.mtvFechaNac.ValidationExpression = Validador.ExpreFecha;
        }

        protected override void ClearForm()
        {
            this.mtvLegajo.Text = string.Empty;
            this.mtvApellido.Text = string.Empty;
            this.mtvNombre.Text = string.Empty;
            this.mtvDireccion.Text = string.Empty;
            this.mtvEmail.Text = string.Empty;
            this.mtvFechaNac.Text = string.Empty;
            this.ddlTipoPersona.ClearSelection();
            this.ddlEspecialidad.ClearSelection();
            this.ddlPlan.ClearSelection();
        }

        protected override void EnableForm(bool enable)
        {
            this.mtvLegajo.Enabled = enable;
            this.mtvApellido.Enabled = enable;
            this.mtvNombre.Enabled = enable;
            this.mtvDireccion.Enabled = enable;
            this.mtvEmail.Enabled = enable;
            this.mtvFechaNac.Enabled = enable;
            this.ddlTipoPersona.Enabled = enable;
            this.ddlEspecialidad.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        protected override void GuardarCambios()
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.entity = new persona();
                    this.LoadEntity(this.entity);
                    this.PersonaLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.PersonaLogic.Delete(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.entity = new persona();
                    this.entity.id_persona = this.SelectedID;
                    this.LoadEntity(this.entity);
                    this.PersonaLogic.Save(this.entity, this.FormMode.ToString());
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