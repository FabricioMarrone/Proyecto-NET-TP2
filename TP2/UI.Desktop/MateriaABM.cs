using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    public partial class MateriaABM : ApplicationForm
    {
        private materia materiaActual;

        public MateriaABM()
        {
            InitializeComponent();
            this.CargarComboBoxEspecialidad();
        }

        public MateriaABM(ModoForm modo) : this() 
        {
            this.Modo = modo;
            this.materiaActual = new materia();
        }

        public MateriaABM(int id, ModoForm modo) : this() 
        {
            this.Modo = modo;
            MateriaLogic materiaLogic = new MateriaLogic();
            this.materiaActual = materiaLogic.GetOne(id);
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
            this.txtIdMateria.Text = this.materiaActual.id_materia.ToString();
            this.txtDescripcion.Text = this.materiaActual.desc_materia;
            this.txtHsSemanales.Text = this.materiaActual.hs_semanales.ToString();
            this.txtHsTotales.Text = this.materiaActual.hs_totales.ToString();

            PlanLogic planLogic = new PlanLogic();
            plane p = planLogic.GetOne(this.materiaActual.id_plan);
            this.cbEspecialidad.SelectedValue = p.id_especialidad;

            this.CargarComboBoxPlan(p.id_especialidad);
            this.cbPlan.SelectedValue = this.materiaActual.id_plan;

            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";

                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtDescripcion.Enabled = false;
                    this.txtHsSemanales.Enabled = false;
                    this.txtHsTotales.Enabled = false;
                    this.cbEspecialidad.Enabled = false;
                    this.cbPlan.Enabled = false;
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            this.materiaActual.desc_materia = this.txtDescripcion.Text;
            this.materiaActual.hs_semanales = Int32.Parse(this.txtHsSemanales.Text);
            this.materiaActual.hs_totales = Int32.Parse(this.txtHsTotales.Text);
            this.materiaActual.id_plan = (int)this.cbPlan.SelectedValue;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            MateriaLogic oMateriaLogic = new MateriaLogic();
            oMateriaLogic.Save(this.materiaActual,this.Modo.ToString());
        }

        public override bool Validar()
        {
            if (this.txtDescripcion.Text.Trim() == "" || 
                this.txtHsSemanales.Text.Trim()==""||
                this.txtHsTotales.Text.Trim()=="")
            {
                this.Notificar("Campos Incompletos", "Todos los campos deben ser completados.",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if( !(Validador.ValidarCadenaSoloTexto(this.txtDescripcion.Text)) )
            {
                this.Notificar("Campos Invalido", "El campo Descripcion es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ( !(Validador.ValidarEnteroPositivo(this.txtHsSemanales.Text)) )
            {
                this.Notificar("Campos Invalido", "El campo Hs Semanales es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!(Validador.ValidarEnteroPositivo(this.txtHsTotales.Text)))
            {
                this.Notificar("Campos Invalido", "El campo Hs Totales es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            this.CargarComboBoxPlan( (int)this.cbEspecialidad.SelectedValue );
        }
    }
}
