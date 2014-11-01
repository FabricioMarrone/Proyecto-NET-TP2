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
            DocenteCursoLogic docCurlogic= new DocenteCursoLogic();
            this.cbCursosDelDocente.DataSource = CursoLogic.getCursosExtended(docCurlogic.getCursosDelDocente(this.personaActual));
            this.cbCursosDelDocente.ValueMember = "id_curso";
            this.cbCursosDelDocente.DisplayMember = "desc";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            PersonaABM form = new PersonaABM(this.personaActual.id_persona, ApplicationForm.ModoForm.Modificacion);
            form.ShowDialog();
            this.updateForm();
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            DocenteCursoABM form = new DocenteCursoABM(this.personaActual.id_persona, this.personaActual.id_plan, ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.updateForm();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            int IdCurso = (int)this.cbCursosDelDocente.SelectedValue;

            CargarNotasCurso cargarNotas = new CargarNotasCurso(this.personaActual,IdCurso);
            cargarNotas.ShowDialog();
            this.updateForm();
        }
    }//end class
}
