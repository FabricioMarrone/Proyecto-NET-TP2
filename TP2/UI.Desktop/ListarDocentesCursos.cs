using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    class ListarDocentesCursos : ListarBase
    {
        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColumn;

            PersonaLogic perLogic = new PersonaLogic();
            dgvColumn = this.CrearNuevaColumna
                (typeColumn.COMBOBOX, "docente", "Docente", "id_persona", "apellido", 
                perLogic.GetAll(persona.tipo.Profesor));
            this.dgvListar.Columns.Add(dgvColumn);

            CursoLogic curLogic = new CursoLogic();
            dgvColumn = this.CrearNuevaColumna
                (typeColumn.COMBOBOX, "curso", "Curso", "id_curso", "id_curso", curLogic.GetAll());
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = this.CrearNuevaColumna("cargo", "Cargo", "cargo");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = this.CrearNuevaColumna("id", "ID", "id_dictado");
            this.dgvListar.Columns.Add(dgvColumn);
        }

        public override void Listar()
        {
            DocenteCursoLogic logic = new DocenteCursoLogic();
            this.dgvListar.DataSource = logic.getAll();
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoABM form = new DocenteCursoABM(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((docentes_cursos)this.dgvListar.SelectedRows[0].DataBoundItem).id_dictado;
                DocenteCursoABM form = new DocenteCursoABM(id, ApplicationForm.ModoForm.Modificacion);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase listar docente cursos");
            }
        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((docentes_cursos)this.dgvListar.SelectedRows[0].DataBoundItem).id_dictado;
                DocenteCursoABM form = new DocenteCursoABM(id, ApplicationForm.ModoForm.Baja);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click  de Clase listar docentes cursos");
            }
        }
    }//end class
}
