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
    public partial class ComisionesABM : ApplicationForm
    {
        public comisione comisionActual;

        public ComisionesABM()
        {
            InitializeComponent();
            this.CargarComboBoxEspecialidad();
        }

        public ComisionesABM(ModoForm modo): this()
        {
            this.Modo = modo;
            this.comisionActual = new comisione();
        }

        public ComisionesABM(int id, ModoForm modo): this()
        {
            this.Modo = modo;
            ComisionLogic logic = new ComisionLogic();
            this.comisionActual = logic.GetOne(id);
            this.MapearDeDatos();
        }

        private void CargarComboBoxEspecialidad()
        {
            EspecialidadLogic espLogic = new EspecialidadLogic();
            this.cbEspecialidad.DataSource = espLogic.GetAll();
            this.cbEspecialidad.ValueMember = "id_especialidad";
            this.cbEspecialidad.DisplayMember = "desc_especialidad";
            this.cbEspecialidad.SelectedItem = null;
            this.cbEspecialidad.Text = "[Especialidad]";

            this.cbPlan.Enabled = false;
        }

        private void CargarComboBoxPlan(int idEspecialidad)
        {
            PlanLogic planLogic = new PlanLogic();
            this.cbPlan.DataSource = planLogic.GetPlanesDeEspecialidad(idEspecialidad);
            // Validar que la lista que devuelva no este vacia.
            // Si esta vacia deshabilitar el boton de aceptar.
            this.cbPlan.ValueMember = "id_plan";
            this.cbPlan.DisplayMember = "desc_plan";
            this.cbPlan.SelectedItem = null;
            this.cbPlan.Text = "[Plan]";


            this.cbPlan.Enabled = true;
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.comisionActual.id_comision.ToString();
            this.txtDesc.Text = this.comisionActual.desc_comision;
            this.txtAñoEsp.Text = this.comisionActual.anio_especialidad.ToString();

            //this.cbPlan.SelectedValue = this.comisionActual.id_plan;
            PlanLogic planLogic = new PlanLogic();
            plane p = planLogic.GetOne(this.comisionActual.id_plan);
            this.cbEspecialidad.SelectedValue = p.id_especialidad;

            this.CargarComboBoxPlan(p.id_especialidad);
            this.cbPlan.SelectedValue = this.comisionActual.id_plan;


            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtID.Enabled = false;
                    this.txtDesc.Enabled = false;
                    this.txtAñoEsp.Enabled = false;
                    this.cbEspecialidad.Enabled = false;
                    this.cbPlan.Enabled = false;
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
            if (this.txtDesc.Text == "" || this.txtAñoEsp.Text == "")
            {
                this.Notificar("Campos Incompletos", "Todos los campos deben ser completados.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!(Validador.ValidarAnioEspecialidad(this.txtAñoEsp.Text)))
            {
                this.Notificar("Campo Invalido", "El campo Año Especialidad es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ( !(Validador.ValidarCadenaTextoYNumeros(this.txtDesc.Text)) )
            {
                this.Notificar("Campos Invalido", "El campo Descripcion es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.cbEspecialidad.SelectedValue == null)
            {
                this.Notificar("Campos Invalido", "Debe seleccionar una Especialidad.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.cbPlan.SelectedValue == null)
            {
                this.Notificar("Campos Invalido", "Debe seleccionar un Plan.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic logic = new ComisionLogic();
            logic.Save(this.comisionActual, this.Modo.ToString());
        }

        public override void MapearADatos()
        {
            //this.comisionActual.id_comision = Int32.Parse(this.txtID.Text);
            this.comisionActual.desc_comision = this.txtDesc.Text;
            this.comisionActual.anio_especialidad = Int32.Parse(this.txtAñoEsp.Text);
            this.comisionActual.id_plan = (int)this.cbPlan.SelectedValue;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.CargarComboBoxPlan((int)this.cbEspecialidad.SelectedValue);
        }


    }//end class
}
