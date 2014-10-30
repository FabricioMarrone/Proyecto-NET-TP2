using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public class ListarEspecialidades : ListarBase
    {
        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColum;

            dgvColum = ListarBase.CrearNuevaColumna("especialidad", "Especialidad", "desc_especialidad");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("id", "ID", "id_especialidad");
            this.dgvListar.Columns.Add(dgvColum);
        }

        public override void Listar()
        {
            EspecialidadLogic logic = new EspecialidadLogic();
            this.dgvListar.DataSource = logic.GetAll();
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            EspecialidadesABM form = new EspecialidadesABM(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try 
            { 
                int id = ((especialidade)this.dgvListar.SelectedRows[0].DataBoundItem).id_especialidad;
                EspecialidadesABM form = new EspecialidadesABM(id, ApplicationForm.ModoForm.Modificacion);
                form.ShowDialog();
                this.Listar();
            }catch(Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase ListarEspecialidades");
            }
        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((especialidade)this.dgvListar.SelectedRows[0].DataBoundItem).id_especialidad;
                EspecialidadesABM form = new EspecialidadesABM(id, ApplicationForm.ModoForm.Baja);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click  de Clase ListarEspecialidades");
            }
        }
    }//end class
}
