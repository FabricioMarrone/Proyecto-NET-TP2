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

namespace UI.Desktop
{
    public partial class ComisionesABM : ApplicationForm
    {
        public comisione comisionActual;

        public ComisionesABM()
        {
            InitializeComponent();
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

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.comisionActual.id_comision.ToString();
            this.txtDesc.Text = this.comisionActual.desc_comision;
            this.txtAñoEsp.Text = this.comisionActual.anio_especialidad.ToString();
            this.txtIDplan.Text = this.comisionActual.id_plan.ToString();

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
                    this.txtIDplan.Enabled = false;
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
            if (this.txtID.Text == "" || this.txtDesc.Text == "" || this.txtAñoEsp.Text == "" || 
                this.txtIDplan.Text == "")
            {
                this.Notificar("Campos Incompletos", "Todos los campos deben ser completados.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.comisionActual.id_comision = Int32.Parse(this.txtID.Text);
            this.comisionActual.desc_comision = this.txtDesc.Text;
            this.comisionActual.anio_especialidad = Int32.Parse(this.txtAñoEsp.Text);
            this.comisionActual.id_plan = Int32.Parse(this.txtIDplan.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end class
}
