using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Desktop
{
    public class ListarUsuarios : ListarBase
    {
        System.Windows.Forms.ToolStripTextBox txtBuscar;

        public ListarUsuarios()
            : base()
        {
            this.Text = "Listar Usuarios";
            this.Size = new System.Drawing.Size(650, 450);
            AgregarBuscadorDeUsuario();
        }

        public override void GenerarColumnas()
        {
            DataGridViewColumn col;

            col = ListarBase.CrearNuevaColumna(typeColumn.CHECKBOX, "habilitado", "Habilitado", "habilitado");
            this.dgvListar.Columns.Add(col);

            col = ListarBase.CrearNuevaColumna("email", "EMail", "email");
            col.Width = 250;
            this.dgvListar.Columns.Add(col);

            col = ListarBase.CrearNuevaColumna("usuario", "Usuario", "nombre_usuario");
            this.dgvListar.Columns.Add(col);

            col = ListarBase.CrearNuevaColumna("nombre", "Nombre", "nombre");
            this.dgvListar.Columns.Add(col);

            col = ListarBase.CrearNuevaColumna("apellido", "Apellido", "apellido");
            this.dgvListar.Columns.Add(col);

            col = ListarBase.CrearNuevaColumna("id", "ID", "id_usuario");
            this.dgvListar.Columns.Add(col);
        }

        public void AgregarBuscadorDeUsuario() 
        {
            //toolstrip textBox Buscar.
            this.txtBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.txtBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 25);


            // toolstrip button Buscar
            System.Windows.Forms.ToolStripButton tsbBuscar = new System.Windows.Forms.ToolStripButton();
            tsbBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tsbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbBuscar.Image = global::UI.Desktop.Properties.Resources.lupa_small;
            tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbBuscar.Name = "tsbBuscar";
            tsbBuscar.Size = new System.Drawing.Size(23, 22);
            tsbBuscar.Text = "Buscar";
            tsbBuscar.Click += new System.EventHandler(tsbBuscar_Click);
            
            this.tsListar.Items.Add(tsbBuscar);
            this.tsListar.Items.Add(txtBuscar);
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarUsuario();
        }

        private void BuscarUsuario() 
        {
            string apellido = txtBuscar.Text;
            if ( (!String.IsNullOrWhiteSpace(apellido)) && Validador.ValidarCadenaSoloTexto(apellido))
	        {
                UsuarioLogic logic = new UsuarioLogic();
                List<usuario> usuarios = logic.BuscarPorApellido(apellido);
                if (usuarios.Count > 0)
                {
                    this.dgvListar.DataSource = usuarios;
                }
                else
                {
                    MessageBox.Show("No existen resultados para su busqueda.");
                }
	        }
            else
            {
                this.Listar();
            }
            txtBuscar.Text = string.Empty;
        }

        public override void Listar()
        {
            UsuarioLogic oUsuarios = new UsuarioLogic();
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
            UsuarioABM formUsuDesk = new UsuarioABM(ApplicationForm.ModoForm.Alta);
            formUsuDesk.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((usuario)this.dgvListar.SelectedRows[0].DataBoundItem).id_usuario;

                UsuarioABM formUsuDesk = new UsuarioABM(id, ApplicationForm.ModoForm.Modificacion);
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
                int id = ((usuario)this.dgvListar.SelectedRows[0].DataBoundItem).id_usuario;

                UsuarioABM formUsuDesk = new UsuarioABM(id, ApplicationForm.ModoForm.Baja);
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
