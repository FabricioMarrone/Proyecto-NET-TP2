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
    public partial class EspecialidadesABM : ApplicationForm
    {
        public especialidade especialidadActual;

        public EspecialidadesABM()
        {
            InitializeComponent();
        }

        public EspecialidadesABM(ModoForm modo) : this() 
        {
            this.Modo = modo;
            this.especialidadActual = new especialidade();
        }

        public EspecialidadesABM(int id, ModoForm modo) : this() 
        {
            this.Modo = modo;
            EspecialidadLogic logic = new EspecialidadLogic();
            this.especialidadActual = logic.GetOne(id);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.especialidadActual.id_especialidad.ToString();
            this.txtDesc.Text = this.especialidadActual.desc_especialidad;

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                     this.txtID.Enabled = false;
                     this.txtDesc.Enabled = false;
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
            if (this.txtDesc.Text == "") {
                this.Notificar("Campos Incompletos", "Todos los campos deben ser completados.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if ( !(Validador.ValidarCadenaSoloTexto(this.txtDesc.Text)) )
            {
                this.Notificar("Campo Invalido", "El campo Descripcion es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            EspecialidadLogic logic = new EspecialidadLogic();
            logic.Save(this.especialidadActual, this.Modo.ToString());
        }

        public override void MapearADatos() 
        {
            this.especialidadActual.desc_especialidad = this.txtDesc.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }//end class
}
