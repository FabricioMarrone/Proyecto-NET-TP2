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
    public partial class MenuAlumno : Form
    {
        private persona personaActual;

        public MenuAlumno()
        {
            InitializeComponent();
            personaActual = new persona();
        }

        public MenuAlumno(persona p) : this() 
        {
            this.personaActual = p;

            this.updateForm();
        }

        public void updateForm() 
        {
            this.lblLegajo.Text = this.personaActual.legajo.ToString();
            this.lblNombre.Text = this.personaActual.nombre;
            this.lblApellido.Text = this.personaActual.apellido;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            PersonaABM form = new PersonaABM(this.personaActual.id_persona, ApplicationForm.ModoForm.Modificacion);
            form.ShowDialog();
            this.updateForm();
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            ListarIncripcionAMateria form = new ListarIncripcionAMateria(this.personaActual);
            form.ShowDialog();
            this.updateForm();
        }


    }//end class
}
