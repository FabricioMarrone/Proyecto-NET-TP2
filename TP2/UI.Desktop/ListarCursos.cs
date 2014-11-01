using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    class ListarCursos : ListarBase
    {
        public ListarCursos()
            : base()
        {
            this.Text = "Listado de Cursos";
        }

        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColum;

            dgvColum = ListarBase.CrearNuevaColumna("cupo", "Cupo", "cupo");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("año", "Año calendario", "anio_calendario");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("comision", "Comision", "comision");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("materia", "Materia", "materia");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("id", "ID", "id_curso");
            this.dgvListar.Columns.Add(dgvColum);
        }

        public override void Listar()
        {
            CursoLogic logic = new CursoLogic();
            this.dgvListar.DataSource = CursoLogic.getCursosExtended(logic.GetAll());
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            CursoABM form = new CursoABM(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((CursoLogic.CursoExtended)this.dgvListar.SelectedRows[0].DataBoundItem).ID_CURSO;
                CursoABM form = new CursoABM(id, ApplicationForm.ModoForm.Modificacion);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase listarcursos");
            }
        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((CursoLogic.CursoExtended)this.dgvListar.SelectedRows[0].DataBoundItem).ID_CURSO;
                CursoABM form = new CursoABM(id, ApplicationForm.ModoForm.Baja);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click  de Clase listarcursos");
            }
        }
    }//end class
}
