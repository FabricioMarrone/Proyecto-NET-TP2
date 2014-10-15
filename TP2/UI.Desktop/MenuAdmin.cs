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
    public partial class MenuAdmin : Form
    {
        private persona personaActual;

        public MenuAdmin()
        {
            InitializeComponent();
            personaActual = new persona();
        }

        public MenuAdmin(persona p)
            : this() 
        {
            this.personaActual = p;

            this.updateForm();
        }

        public void updateForm() 
        {
            this.lblUsuario.Text = this.personaActual.nombre;
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            ListarEspecialidades form = new ListarEspecialidades();
            form.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            ListarPlanes form = new ListarPlanes();
            form.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            ListarMaterias form = new ListarMaterias();
            form.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            ListarComisiones form = new ListarComisiones();
            form.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            ListarCursos form = new ListarCursos();
            form.ShowDialog();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            ListarPersonas form = new ListarPersonas();
            form.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ListarUsuarios form = new ListarUsuarios();
            form.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }//end class
}
