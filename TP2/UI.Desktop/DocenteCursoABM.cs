using System;
using System.Collections;
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
        private int id_docente;
        private int id_plan;

        public DocenteCursoABM()
        {
            InitializeComponent();

        }

        public DocenteCursoABM(ModoForm modo)
            : this()
        {
            this.Modo = modo;
            this.docenteCursoActual = new docentes_cursos();
        }

        //UNICAMENTE SE USA ALTA
        public DocenteCursoABM(int id_docente,int id_plan, ModoForm modo) : this() 
        {
            this.Modo = modo;
            this.docenteCursoActual = new docentes_cursos();
            this.id_docente = id_docente;
            this.id_plan = id_plan;
            this.MapearDeDatos();
            this.cbProfesores.Enabled = false;
            this.cbProfesores.SelectedValue = id_docente;
        }

        public DocenteCursoABM(int id_docente, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            this.docenteCursoActual = new docentes_cursos();
            this.id_docente = id_docente;
            this.MapearDeDatos();
            this.cbProfesores.Enabled = false;
            this.cbProfesores.SelectedValue = id_docente;
        }

        private void loadComboBoxes() 
        {
            PersonaLogic perLogic = new PersonaLogic();
            this.cbProfesores.DataSource = PersonaLogic.getPersonasExtended(perLogic.GetAll(persona.tipo.Profesor));
            this.cbProfesores.ValueMember = "id_persona";
            this.cbProfesores.DisplayMember = "desc";



            MateriaLogic matLogic = new MateriaLogic();
            this.cbMateria.DataSource = matLogic.GetMateriasParaDictado(id_docente,id_plan);
            this.cbMateria.ValueMember = "id_materia";
            this.cbMateria.DisplayMember = "desc_materia";
            this.cbMateria.SelectedItem = null;
            this.cbMateria.Text = "[Seleccione una Materia]";

            this.cbCursos.Enabled = false;

            this.cbCargos.DataSource = Enum.GetValues(typeof(persona.cargo));
        }

        public override void MapearDeDatos()
        {
            //this.txtID.Text = this.docenteCursoActual.id_dictado.ToString();
            //this.cbCargos.SelectedIndex = this.docenteCursoActual.cargo;
            //this.cbProfesores.SelectedValue = this.docenteCursoActual.id_docente;
            //this.cbCursos.SelectedValue = this.docenteCursoActual.id_curso;
             
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

        public override bool Validar() 
        {
            if (this.cbMateria.SelectedValue == null)
            {
                this.Notificar("Campos Incompletos", "Deben seleccionar una Materia.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.cbCursos.SelectedValue == null)
            {
                this.Notificar("Campos Incompletos", "Deben seleccionar una Curso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
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

        private void DocenteCursoABM_Load(object sender, EventArgs e)
        {
            this.loadComboBoxes();
        }

        private void cbMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Aca haga la busqueda de la comisiones.
            int idMateria = (int)this.cbMateria.SelectedValue;

            //buscar comisiones disponibles.
            CursoLogic curLogic = new CursoLogic();
            this.cbCursos.DataSource = CursoLogic.getCursosExtended(curLogic.GetCursosParaDictado(idMateria));

            this.cbCursos.ValueMember = "id_curso";
            this.cbCursos.DisplayMember = "comision";
            this.cbCursos.SelectedItem = null;
            this.cbCursos.Text = "[Seleccione un Curso]";
            this.cbCursos.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }//end class
}
