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

namespace UI.Desktop
{
    public partial class ModuloABM : ApplicationForm
    {
        private modulo moduloActual;

        public ModuloABM()
        {
            InitializeComponent();
        }

        public ModuloABM(ModoForm modo) : this() 
        {
            this.Modo = modo;
            this.moduloActual = new modulo();
        }

        public ModuloABM(int id, ModoForm modo) : this() 
        {
            this.Modo = modo;
            ModuloLogic logic = new ModuloLogic();
            this.moduloActual = logic.GetOne(id);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.moduloActual.id_modulo.ToString();
            this.txtDesc.Text = this.moduloActual.desc_modulo;
            this.txtEjecuta.Text = this.moduloActual.ejecuta;

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtID.Enabled = false;
                    this.txtDesc.Enabled = false;
                    this.txtEjecuta.Enabled = false;
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
            if (this.txtDesc.Text == "" || this.txtEjecuta.Text == "")
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
            ModuloLogic logic = new ModuloLogic();
            logic.Save(this.moduloActual, this.Modo.ToString());
        }

        public override void MapearADatos()
        {
            this.moduloActual.id_modulo = Int32.Parse(this.txtID.Text);
            this.moduloActual.desc_modulo = this.txtDesc.Text;
            this.moduloActual.ejecuta = this.txtEjecuta.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end class
}
