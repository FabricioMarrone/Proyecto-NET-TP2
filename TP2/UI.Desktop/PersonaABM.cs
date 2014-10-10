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
    public partial class PersonaABM : ApplicationForm
    {
        private persona personaActual;

        public PersonaABM()
        {
            InitializeComponent();
            this.CargarComboBox();
        }

        public PersonaABM(ModoForm modo) : this() 
        {
            this.Modo = modo;
            this.personaActual = new persona();
        }

        public PersonaABM(int id, ModoForm modo) : this() 
        {
            this.Modo = modo;
            PersonaLogic logic = new PersonaLogic();
            this.personaActual = logic.GetOne(id);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.personaActual.id_persona.ToString();
            this.txtNombre.Text = this.personaActual.nombre;
            this.txtApellido.Text = this.personaActual.apellido;
            this.txtlegajo.Text = this.personaActual.legajo.ToString();
            this.txtDireccion.Text = this.personaActual.direccion;
            this.txtEmail.Text = this.personaActual.email;
            this.txtTelefono.Text = this.personaActual.telefono;
            this.txtFechaNac.Text = this.personaActual.fecha_nac.ToShortDateString();
            this.cbTiposPer.SelectedIndex = this.personaActual.tipo_persona;
            this.cbPlanes.SelectedValue = this.personaActual.id_plan;

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtID.Enabled = false;
                    this.txtNombre.Enabled = false;
                    this.txtApellido.Enabled = false;
                    this.txtlegajo.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtEmail.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.txtFechaNac.Enabled = false;
                    this.cbTiposPer.Enabled = false;
                    this.cbPlanes.Enabled = false;
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    this.txtID.Enabled = false;
                    break;
            }
        }

        private void CargarComboBox()
        {
            PlanLogic planLogic = new PlanLogic();
            this.cbPlanes.DataSource = planLogic.GetAll();
            this.cbPlanes.ValueMember = "id_plan";
            this.cbPlanes.DisplayMember = "desc_plan";

            this.cbTiposPer.DataSource = Enum.GetValues(typeof(persona.tipo));
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
            //if (this.txtAñoCalendario.Text == "" || this.txtCupo.Text == "")
            //{
            //    this.Notificar("Campos Incompletos", "Todos los campos deben ser completados.",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            this.Notificar("Atencion", "Este form no se esta validando (clase PersonaABM, metodo Validar).",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaLogic logic = new PersonaLogic();
            logic.Save(this.personaActual, this.Modo.ToString());
        }

        public override void MapearADatos()
        {
            this.personaActual.nombre = this.txtNombre.Text;
            this.personaActual.apellido = this.txtApellido.Text;
            this.personaActual.legajo = Int32.Parse(this.txtlegajo.Text);
            this.personaActual.direccion = this.txtDireccion.Text;
            this.personaActual.email = this.txtEmail.Text;
            this.personaActual.telefono = this.txtTelefono.Text;
            this.personaActual.fecha_nac = DateTime.Parse(this.txtFechaNac.Text);
            this.personaActual.tipo_persona = this.cbTiposPer.SelectedIndex;
            this.personaActual.id_plan= (int)this.cbPlanes.SelectedValue;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end class
}
