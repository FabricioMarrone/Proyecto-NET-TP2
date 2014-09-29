using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;

            this.GenerarColumnas();
        }

        private void GenerarColumnas()
        {
            
            DataGridViewColumn col;

            col = this.CrearNuevaColumna("DataGridViewCheckBoxColumn", "habilitado", "Habilitado", "habilitado");
            this.dgvUsuarios.Columns.Add(col);

            col = this.CrearNuevaColumna("email", "EMail", "email");
            col.Width = 250;
            this.dgvUsuarios.Columns.Add(col);

            col = this.CrearNuevaColumna("usuario", "Usuario", "nombre_usuario");
            this.dgvUsuarios.Columns.Add(col);

            col = this.CrearNuevaColumna("nombre", "Nombre", "nombre");
            this.dgvUsuarios.Columns.Add(col);

            col = this.CrearNuevaColumna("apellido", "Apellido", "apellido");
            this.dgvUsuarios.Columns.Add(col);


            col = this.CrearNuevaColumna("id", "ID", "id_usuario");
            this.dgvUsuarios.Columns.Add(col);
            
        }

        private DataGridViewColumn CrearNuevaColumna(string type, string name, string header, string propName)
        {
            DataGridViewColumn dgvc;
            switch (type)
            {
                case "DataGridViewTextBoxColumn":
                    dgvc = new DataGridViewTextBoxColumn();
                    break;
                case "DataGridViewCheckBoxColumn":
                    dgvc = new DataGridViewCheckBoxColumn();
                    break;
                default:
                    dgvc = new DataGridViewColumn();
                    break;
            }

            dgvc.Name = name;
            dgvc.HeaderText = header;
            dgvc.DataPropertyName = propName;
            dgvc.DisplayIndex = 0;

            return dgvc;
        }

        private DataGridViewColumn CrearNuevaColumna(string name, string header, string propName)
        {
            return CrearNuevaColumna("DataGridViewTextBoxColumn", name, header, propName);
        }

        public void Listar() 
        {
            Business.Logic.UsuarioLogic oUsuarios = new Business.Logic.UsuarioLogic();
            try
            {                
                this.dgvUsuarios.DataSource = oUsuarios.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UI.Desktop.UsuarioDesktop formUsuDesk = new UsuarioDesktop(UsuarioDesktop.ModoForm.Alta);
            formUsuDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Business.Entities.usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).id_usuario;

                UI.Desktop.UsuarioDesktop formUsuDesk = new UsuarioDesktop(id, UsuarioDesktop.ModoForm.Modificacion);
                formUsuDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase Usuario Form");
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Business.Entities.usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).id_usuario;

                UI.Desktop.UsuarioDesktop formUsuDesk = new UsuarioDesktop(id, UsuarioDesktop.ModoForm.Baja);
                formUsuDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click de Clase Usuario Form");
            }
        }
    }
}
