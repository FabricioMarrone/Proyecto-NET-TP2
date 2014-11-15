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
        private EspecialidadLogic espLogic;

        public EspecialidadLogic EspLogic
        {
            get
            {
                if (this.espLogic == null) this.espLogic = new EspecialidadLogic();
                return this.espLogic;
            }
        }


        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private especialidade especialidad;

        private int SelectedID
        {
            get {
                if (this.ViewState["SelectedID"] != null) return (int)this.ViewState["SelectedID"];
                
                else return 0;
                
            }
            set { this.ViewState["SelectedID"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if ( !this.IsPostBack )
            {
                persona personaActual = (persona)this.Session[Global.PERSONA_ACTUAL];
                if (personaActual != null && personaActual.tipo_persona == (int)persona.tipo.Admin)
                {
                    
                }
                this.CargarExpresionesRegulares();



            }
        }

        private void MapearDeDatos(especialidade esp) 
        {
            this.txtId.Text = esp.id_especialidad.ToString();
            this.txtEspecialidad.Text = esp.desc_especialidad;
        }

        private especialidade MapearADatos()
        {
            especialidade esp = new especialidade();
            esp.id_especialidad = int.Parse(this.txtId.Text);
            esp.desc_especialidad = this.txtEspecialidad.Text;
            return esp;
        }

        private void CargarExpresionesRegulares() 
        {
            this.revEspecialidad.ValidationExpression = Util.Validador.ExpreCadenaSoloTexto;
        }

        private bool Validar() 
        {

            return true;
        }

        private void GuardarCambios()
        {
            //this.ViewState[""];

            especialidade esp = this.MapearADatos();
            EspecialidadLogic espLogic = new EspecialidadLogic();
            espLogic.Save(esp, ((FormModes)this.ViewState["FormMode"]).ToString());
        }

        protected void lbAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.MapearADatos();
                this.GuardarCambios();
            }
        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}