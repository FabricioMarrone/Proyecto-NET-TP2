using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Desktop
{
    public partial class PlanesABM : ApplicationForm
    {
        private plane planActual;

        public PlanesABM()
        {
            InitializeComponent();

            //Cargamos el combobox
            EspecialidadLogic espLogic = new EspecialidadLogic();
            this.cbEspecialidad.DataSource = espLogic.GetAll();
            this.cbEspecialidad.ValueMember = "id_especialidad";
            this.cbEspecialidad.DisplayMember = "desc_especialidad";
            this.cbEspecialidad.SelectedItem = null;
            this.cbEspecialidad.Text = "[Especialidad]";
        }

        public PlanesABM(ModoForm modo) : this() 
        {
            this.Modo = modo;
            this.planActual = new plane();
        }

        public PlanesABM(int id, ModoForm modo) : this() 
        {
            this.Modo = modo;
            PlanLogic logic = new PlanLogic();
            this.planActual = logic.GetOne(id);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.planActual.id_plan.ToString();
            this.txtDesc.Text = this.planActual.desc_plan;
            this.cbEspecialidad.SelectedValue = this.planActual.id_especialidad;

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtID.Enabled = false;
                    this.txtDesc.Enabled = false;
                    this.cbEspecialidad.Enabled = false;
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
            if (this.txtDesc.Text == "" )
            {
                this.Notificar("Campos Incompletos", "Todos los campos deben ser completados.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ( !(Validador.ValidarCadenaTextoYNumeros(this.txtDesc.Text)))
            {
                this.Notificar("Campos Invalido", "El campo Descripcion es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ( this.cbEspecialidad.SelectedValue == null)
            {
                this.Notificar("Campos Invalido", "Debe selccionar una Especialidad.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PlanLogic logic = new PlanLogic();
            logic.Save(this.planActual, this.Modo.ToString());
        }

        public override void MapearADatos()
        {
            this.planActual.desc_plan = this.txtDesc.Text;
            this.planActual.id_especialidad = (int)this.cbEspecialidad.SelectedValue;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end class
}
