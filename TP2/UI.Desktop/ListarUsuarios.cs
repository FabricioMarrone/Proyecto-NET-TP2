using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public class ListarUsuarios : ListarBase
    {
        public override void GenerarColumnas()
        {
            DataGridViewColumn col;

            col = this.CrearNuevaColumna(typeColumn.CHECKBOX, "habilitado", "Habilitado", "habilitado");
            this.dgvListar.Columns.Add(col);

            col = this.CrearNuevaColumna("email", "EMail", "email");
            col.Width = 250;
            this.dgvListar.Columns.Add(col);

            col = this.CrearNuevaColumna("usuario", "Usuario", "nombre_usuario");
            this.dgvListar.Columns.Add(col);

            col = this.CrearNuevaColumna("nombre", "Nombre", "nombre");
            this.dgvListar.Columns.Add(col);

            col = this.CrearNuevaColumna("apellido", "Apellido", "apellido");
            this.dgvListar.Columns.Add(col);

            col = this.CrearNuevaColumna("id", "ID", "id_usuario");
            this.dgvListar.Columns.Add(col);
        }

        public override void Listar()
        {
            Business.Logic.UsuarioLogic oUsuarios = new Business.Logic.UsuarioLogic();
            try
            {
                this.dgvListar.DataSource = oUsuarios.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            UI.Desktop.UsuarioABM formUsuDesk = new UsuarioABM(UsuarioABM.ModoForm.Alta);
            formUsuDesk.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Business.Entities.usuario)this.dgvListar.SelectedRows[0].DataBoundItem).id_usuario;

                UI.Desktop.UsuarioABM formUsuDesk = new UsuarioABM(id, UsuarioABM.ModoForm.Modificacion);
                formUsuDesk.ShowDialog();
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
                int id = ((Business.Entities.usuario)this.dgvListar.SelectedRows[0].DataBoundItem).id_usuario;

                UI.Desktop.UsuarioABM formUsuDesk = new UsuarioABM(id, UsuarioABM.ModoForm.Baja);
                formUsuDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click de Clase Usuario Form");
            }
        }
    }//end class
}
