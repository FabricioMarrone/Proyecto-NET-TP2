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
    public partial class AlumnoEstadoAcademico : Form
    {
        public AlumnoEstadoAcademico(persona per)
        {
            InitializeComponent();

            this.loadGrid(per);
        }

        private void loadGrid(persona per) 
        {
            InscripcionAlumnoLogic logic= new InscripcionAlumnoLogic();
            this.dgvInscripciones.DataSource = logic.getInscripcionesDelAlumno(per);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end class
}
