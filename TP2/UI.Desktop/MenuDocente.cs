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
    public partial class MenuDocente : Form
    {
        private persona personaActual;

        public MenuDocente()
        {
            InitializeComponent();
            personaActual = new persona();
        }

        public MenuDocente(persona p) : this() 
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
    }//end class
}
