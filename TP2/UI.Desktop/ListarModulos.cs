using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    class ListarModulos : ListarBase
    {
        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColumn;

            dgvColumn = ListarBase.CrearNuevaColumna("ejecuta", "Ejecuta", "ejecuta");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = ListarBase.CrearNuevaColumna("descipcion", "Descripcion", "desc_modulo");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = ListarBase.CrearNuevaColumna("id", "ID", "id_modulo");
            this.dgvListar.Columns.Add(dgvColumn);
        }

        public override void Listar()
        {
            ModuloLogic logic = new ModuloLogic();
            this.dgvListar.DataSource = logic.GetAll();
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            ModuloABM form = new ModuloABM(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((modulo)this.dgvListar.SelectedRows[0].DataBoundItem).id_modulo;
                ModuloABM form = new ModuloABM(id, ApplicationForm.ModoForm.Modificacion);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase listarmodulos");
            }
        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((modulo)this.dgvListar.SelectedRows[0].DataBoundItem).id_modulo;
                ModuloABM form = new ModuloABM(id, ApplicationForm.ModoForm.Baja);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click  de Clase listarmodulos");
            }
        }
    }//end class
}
