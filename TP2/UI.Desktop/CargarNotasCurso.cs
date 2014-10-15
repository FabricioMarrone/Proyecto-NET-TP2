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
    public partial class CargarNotasCurso : Form
    {
        private persona docenteActual;
        private curso cursoActual;

        public CargarNotasCurso(persona docente, curso curso)
        {
            InitializeComponent();
            this.docenteActual = docente;
            this.cursoActual = curso;
            this.updateForm();
        }

        private void updateForm() 
        {
            this.lblApellidoDocente.Text = this.docenteActual.apellido;
            //this.dgvAlumnosDelCurso.DataSource = this.cursoActual.alumnos_inscripciones;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }//end class
}
