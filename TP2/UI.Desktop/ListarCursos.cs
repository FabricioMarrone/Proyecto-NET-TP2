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
        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColum;

            dgvColum = this.CrearNuevaColumna("cupo", "Cupo", "cupo");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = this.CrearNuevaColumna("año", "Año calendario", "anio_calendario");
            this.dgvListar.Columns.Add(dgvColum);

            ComisionLogic comLogic = new ComisionLogic();
            dgvColum = this.CrearNuevaColumna
                (typeColumn.COMBOBOX, "comision", "Comision", "id_comision", "desc_comision", comLogic.GetAll());
            this.dgvListar.Columns.Add(dgvColum);
            //dgvColum = this.CrearNuevaColumna("comision", "Comision", "id_comision");
            //this.dgvListar.Columns.Add(dgvColum);

            MateriaLogic matLogic = new MateriaLogic();
            dgvColum = this.CrearNuevaColumna
                (typeColumn.COMBOBOX, "materia", "Materia", "id_materia", "desc_materia", matLogic.GetAll());
            this.dgvListar.Columns.Add(dgvColum);
            //dgvColum = this.CrearNuevaColumna("materia", "Materia", "id_materia");
            //this.dgvListar.Columns.Add(dgvColum);

            dgvColum = this.CrearNuevaColumna("id", "ID", "id_curso");
            this.dgvListar.Columns.Add(dgvColum);

           
        }

        public override void Listar()
        {
            CursoLogic logic = new CursoLogic();
            this.dgvListar.DataSource = logic.GetAll();
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
                int id = ((curso)this.dgvListar.SelectedRows[0].DataBoundItem).id_curso;
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
                int id = ((curso)this.dgvListar.SelectedRows[0].DataBoundItem).id_curso;
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
