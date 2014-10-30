using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    class ListarInscripcionesAlumnos : ListarBase
    {
        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColumn;

            dgvColumn = ListarBase.CrearNuevaColumna("nota", "nota", "nota");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = ListarBase.CrearNuevaColumna("condicion", "condicion", "condicion");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = ListarBase.CrearNuevaColumna("curso", "Curso", "id_curso");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = ListarBase.CrearNuevaColumna("alumno", "Alumno", "id_alumno");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = ListarBase.CrearNuevaColumna("id", "ID", "id_inscripcion");
            this.dgvListar.Columns.Add(dgvColumn);
        }

        public override void Listar()
        {
            InscripcionAlumnoLogic logic = new InscripcionAlumnoLogic();
            this.dgvListar.DataSource = logic.GetAll();
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            InscripcionAlumnoABM form = new InscripcionAlumnoABM(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((alumnos_inscripciones)this.dgvListar.SelectedRows[0].DataBoundItem).id_inscripcion;
                InscripcionAlumnoABM form = new InscripcionAlumnoABM(id, ApplicationForm.ModoForm.Modificacion);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase listaraluminscrip");
            }
        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((alumnos_inscripciones)this.dgvListar.SelectedRows[0].DataBoundItem).id_inscripcion;
                InscripcionAlumnoABM form = new InscripcionAlumnoABM(id, ApplicationForm.ModoForm.Baja);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click  de Clase listaralumn inscrip");
            }
        }
    }//end class
}
