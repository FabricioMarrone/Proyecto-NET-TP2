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
    public partial class CursoABM : ApplicationForm
    {
        private curso cursoActual;

        public CursoABM()
        {
            InitializeComponent();
            this.CargarComboBox();
        }

        public CursoABM(ModoForm modo) : this() 
        {
            this.Modo = modo;
            this.cursoActual = new curso();
        }

        public CursoABM(int id, ModoForm modo) : this() 
        {
            this.Modo = modo;
            CursoLogic logic = new CursoLogic();
            this.cursoActual = logic.GetOne(id);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.cursoActual.id_curso.ToString();
            this.txtAñoCalendario.Text = this.cursoActual.anio_calendario.ToString();
            this.txtCupo.Text = this.cursoActual.cupo.ToString();
            this.cbMaterias.SelectedValue = this.cursoActual.id_materia;
            this.cbComisiones.SelectedValue = this.cursoActual.id_comision;

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtID.Enabled = false;
                    this.txtAñoCalendario.Enabled = false;
                    this.txtCupo.Enabled = false;
                    this.cbMaterias.Enabled = false;
                    this.cbComisiones.Enabled = false;
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    this.txtID.Enabled = false;
                    break;
            }
        }

        private void CargarComboBox()
        {
            MateriaLogic matLogic = new MateriaLogic();
            this.cbMaterias.DataSource = matLogic.GetAll();
            this.cbMaterias.ValueMember = "id_materia";
            this.cbMaterias.DisplayMember = "desc_materia";

            ComisionLogic comLogic = new ComisionLogic();
            this.cbComisiones.DataSource = comLogic.GetAll();
            this.cbComisiones.ValueMember = "id_comision";
            this.cbComisiones.DisplayMember = "desc_comision";
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
            if (this.txtAñoCalendario.Text == "" || this.txtCupo.Text == "")
            {
                this.Notificar("Campos Incompletos", "Todos los campos deben ser completados.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!(Validador.ValidarAnio(this.txtAñoCalendario.Text)))
            {
                this.Notificar("Campo Invalido", "El campo Año Calendario es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ( !(Validador.ValidarEnteroPositivo(this.txtCupo.Text)) )
            {
                this.Notificar("Campo Invalido", "El campo Cupo es Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            CursoLogic logic = new CursoLogic();
            logic.Save(this.cursoActual, this.Modo.ToString());
        }

        public override void MapearADatos()
        {
            this.cursoActual.anio_calendario = Int32.Parse(this.txtAñoCalendario.Text);
            this.cursoActual.cupo = Int32.Parse(this.txtCupo.Text);
            this.cursoActual.id_materia = (int)this.cbMaterias.SelectedValue;
            this.cursoActual.id_comision = (int)this.cbComisiones.SelectedValue;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end class
}
