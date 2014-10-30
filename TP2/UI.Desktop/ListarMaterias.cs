using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    class ListarMaterias : ListarBase
    {
        public ListarMaterias() : base()
        {
            this.Text = "Listar Materias";
        }

        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColum;

            dgvColum = ListarBase.CrearNuevaColumna("plan", "Plan", "plan");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("horasTotales", "Horas Totales", "hs_totales");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("horasSemanales", "Horas Semanales", "hs_semanales");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("descMateria", "Descripcion Materia", "desc_materia");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("idMateria", "ID", "id_materia");
            this.dgvListar.Columns.Add(dgvColum);
        }

        public override void Listar()
        {
            MateriaLogic materiaLogic = new MateriaLogic();
            try
            {
                this.dgvListar.DataSource = MateriaLogic.getMateriasExtended(materiaLogic.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            MateriaABM formMatAbm = new MateriaABM(ApplicationForm.ModoForm.Alta);
            formMatAbm.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((materia)this.dgvListar.SelectedRows[0].DataBoundItem).id_materia;

                MateriaABM formMatAbm = new MateriaABM(id,ApplicationForm.ModoForm.Modificacion);
                formMatAbm.ShowDialog();
                this.Listar();

            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase Usuario Form");
            }
        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((materia)this.dgvListar.SelectedRows[0].DataBoundItem).id_materia;
                MateriaABM formMatAbm = new MateriaABM(id,ApplicationForm.ModoForm.Baja);
                formMatAbm.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase Usuario Form");
            }
        }

    }
}
