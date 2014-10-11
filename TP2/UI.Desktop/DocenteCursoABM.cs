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
    public partial class DocenteCursoABM : ApplicationForm
    {
        private docentes_cursos docenteCursoActual;

        public DocenteCursoABM()
        {
            InitializeComponent();
            this.loadComboBoxes();
        }

        public DocenteCursoABM(ModoForm modo) : this() 
        {
            this.Modo = modo;
            this.docenteCursoActual = new docentes_cursos();
        }

        public DocenteCursoABM(int id, ModoForm modo) : this() 
        {
            this.Modo = modo;
            DocenteCursoLogic logic = new DocenteCursoLogic();
            this.docenteCursoActual = logic.GetOne(id);
            this.MapearDeDatos();
        }

        private void loadComboBoxes() 
        {
            PersonaLogic perLogic = new PersonaLogic();
            this.cbProfesores.DataSource = perLogic.GetAll(persona.tipo.Profesor);
            this.cbProfesores.ValueMember = "id_persona";
            this.cbProfesores.DisplayMember = "apellido";

            CursoLogic curLogic = new CursoLogic();
            this.cbCursos.DataSource = curLogic.GetAll();
            this.cbCursos.ValueMember = "id_curso";
            this.cbCursos.DisplayMember = "id_curso";

            this.cbCargos.DataSource = Enum.GetValues(typeof(persona.cargo));
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.docenteCursoActual.id_dictado.ToString();
            this.cbCargos.SelectedIndex = this.docenteCursoActual.cargo;
            this.cbProfesores.SelectedValue = this.docenteCursoActual.id_docente;
            this.cbCursos.SelectedValue = this.docenteCursoActual.id_curso;
             
            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";

                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.cbCargos.Enabled = false;
                    this.cbProfesores.Enabled = false;
                    this.cbCursos.Enabled = false;
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";

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

            this.Notificar("Atencion", "No se esta validando el formulario (ProfesorCursoABM)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            DocenteCursoLogic logic = new DocenteCursoLogic();
            logic.save(this.docenteCursoActual, this.Modo.ToString());

        }

        public override void MapearADatos()
        {
            this.docenteCursoActual.id_docente = (int)this.cbProfesores.SelectedValue;
            this.docenteCursoActual.id_curso = (int)this.cbCursos.SelectedValue;
            this.docenteCursoActual.cargo = this.cbCargos.SelectedIndex;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end class
}
