using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    class ListarPlanes : ListarBase
    {
        public ListarPlanes() : base()
        {
            this.Text = "Listado de Planes";
        }

        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColumn;

            dgvColumn = ListarBase.CrearNuevaColumna("especialidad", "Especialidad", "especialidad");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = ListarBase.CrearNuevaColumna("plan", "plan", "desc_plan");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = ListarBase.CrearNuevaColumna("id", "ID", "id_plan");
            this.dgvListar.Columns.Add(dgvColumn);
        }

        public override void Listar()
        {
            PlanLogic logic = new PlanLogic();
            this.dgvListar.DataSource = PlanLogic.getPlanesExtended(logic.GetAll());
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            PlanesABM form = new PlanesABM(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((PlanLogic.PlanExtended)this.dgvListar.SelectedRows[0].DataBoundItem).Id_plan;
                PlanesABM form = new PlanesABM(id, ApplicationForm.ModoForm.Modificacion);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase listarplanes");
            }
        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((PlanLogic.PlanExtended)this.dgvListar.SelectedRows[0].DataBoundItem).Id_plan;
                PlanesABM form = new PlanesABM(id, ApplicationForm.ModoForm.Baja);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click  de Clase listaplanes");
            }
        }
    }//end class
}
