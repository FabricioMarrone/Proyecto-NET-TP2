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
    public partial class ModificarDatos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (this.Session[Global.PERSONA_ACTUAL] != null)
                {
                    this.loadDropDownLists();
                    this.mapearDeDatos((persona)this.Session[Global.PERSONA_ACTUAL]);
                }
            }
            this.CargarExpresionesRegulares();
        }

        public void loadDropDownLists() 
        {
            this.ddlTipo.DataSource = Enum.GetValues(typeof(persona.tipo));
            this.ddlTipo.DataBind();

            PlanLogic planLogic = new PlanLogic();
            this.ddlPlan.DataSource = planLogic.GetAll();
            this.ddlPlan.DataValueField = "id_plan";
            this.ddlPlan.DataTextField = "desc_plan";
            this.ddlPlan.DataBind();
        }

        public void mapearDeDatos(persona per) 
        {
            this.txtNombre.Text = per.nombre;
            this.txtApellido.Text = per.apellido;
            this.txtLegajo.Text = per.legajo.ToString();
            this.txtDireccion.Text = per.direccion;
            this.txtEmail.Text = per.email;
            this.txtTelefono.Text = per.telefono;
            this.txtFechaNac.Text = per.fecha_nac.ToShortDateString();
            this.ddlTipo.SelectedIndex = per.tipo_persona;
            this.ddlPlan.SelectedValue = per.id_plan.ToString();

            txtLegajo.Enabled = false;

            switch (per.tipo_persona)
            {
                case (int)persona.tipo.Alumno:
                case (int)persona.tipo.Profesor:
                    ddlTipo.Enabled = false;
                    ddlPlan.Enabled = false;
                    break;
                case (int)persona.tipo.Admin:

                    break;
            }//end switch

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
            }
        }

        public bool Validar() 
        {
            //this.planMessage.Text="";
            //this.tipoMessage.Text = "";
            //if (this.ddlPlan.SelectedValue == null)
            //{
            //    this.planMessage.Text = "Debe selecionar un Plan.";
            //    return false;
            //}
            //if (this.ddlTipo.SelectedValue != null)
            //{
            //    this.tipoMessage.Text = "Debe selecionar un Tipo de Usuario.";
            //    return false;
            //}

            return true;
        }

        public void GuardarCambios() 
        {
            persona per = (persona)this.Session[Global.PERSONA_ACTUAL];
            this.mapearAdatos(per);
            PersonaLogic logic = new PersonaLogic();
            logic.Save(per, "Modificacion");
            this.lblOperationMessage.Text = "Datos modificados correctamente.";
            //Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Datos modificados correctamente.')</SCRIPT>");
        }

        public void mapearAdatos(persona per) 
        {
            per.nombre = this.txtNombre.Text;
            per.apellido = this.txtApellido.Text;
            per.legajo = Int32.Parse(this.txtLegajo.Text);
            per.direccion = this.txtDireccion.Text;
            per.email = this.txtEmail.Text;
            per.telefono = this.txtTelefono.Text;
            per.fecha_nac = DateTime.Parse(this.txtFechaNac.Text);
            per.tipo_persona = this.ddlTipo.SelectedIndex;
            per.id_plan = Int32.Parse(this.ddlPlan.SelectedValue);
        }

        private void CargarExpresionesRegulares() 
        { 
            this.revLegajo.ValidationExpression = Validador.ExpreLegajo;
            this.revNombre.ValidationExpression = Validador.ExpreCadenaSoloTexto;
            this.revApellido.ValidationExpression = Validador.ExpreCadenaSoloTexto;
            this.revDireccion.ValidationExpression = Validador.ExpreDireccion;
            this.revEmail.ValidationExpression = Validador.ExpreEMail;
            this.revTelefono.ValidationExpression = Validador.ExpreTelefono;
            this.revFechaNac.ValidationExpression = Validador.ExpreFecha;
        }
    }//end class
}