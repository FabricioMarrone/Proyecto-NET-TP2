using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    class ListarPersonas : ListarBase
    {

        System.Windows.Forms.ToolStripTextBox txtBuscar;

        public ListarPersonas()
            : base()
        {
            this.Text = "Listado de Personas";
            this.Width = this.Width + 300;

            this.AgregarBuscadorDePersona();
        }

        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColum;

            dgvColum = ListarBase.CrearNuevaColumna("Plan", "Plan", "plan");
            this.dgvListar.Columns.Add(dgvColum);

            //No funca el combo con el enum!!
            //dgvColum = this.CrearNuevaColumna
            //    (typeColumn.COMBOBOX, "tipoPersona", "Tipo persona", null, null, 
            //    Enum.GetValues(typeof(persona.tipo)));
            dgvColum = ListarBase.CrearNuevaColumna("tipoPersona", "Tipo persona", "tipo_persona");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("fechaNac", "Fecha Nacimiento", "fecha_nac");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("telefono", "Telefono", "telefono");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("email", "Email", "email");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("direccion", "Direccion", "direccion");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("apellido", "Apellido", "apellido");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("nombre", "Nombre", "nombre");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("legajo", "Legajo", "legajo");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("id_persona", "ID", "id_persona");
            dgvColum.Visible = false;
            this.dgvListar.Columns.Add(dgvColum);
        }

        public void AgregarBuscadorDePersona()
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
            string ingreso = txtBuscar.Text.ToString();
            if ((!String.IsNullOrWhiteSpace(ingreso)) && Validador.ValidarLegajo(ingreso))
            {
                int legajo = int.Parse(ingreso);

                PersonaLogic logic = new PersonaLogic();
                List<persona> personas = logic.BuscarPorLegajo(legajo);
                if (personas.Count > 0)
                {
                    this.dgvListar.DataSource = PersonaLogic.getPersonasExtended(personas);
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
            PersonaLogic logic = new PersonaLogic();
            this.dgvListar.DataSource = PersonaLogic.getPersonasExtended(logic.GetAll());
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            PersonaABM form = new PersonaABM(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((PersonaLogic.PersonaExtended)this.dgvListar.SelectedRows[0].DataBoundItem).Id_persona;
                PersonaABM form = new PersonaABM(id, ApplicationForm.ModoForm.Modificacion);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase listarpersonas");
            }
        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((PersonaLogic.PersonaExtended)this.dgvListar.SelectedRows[0].DataBoundItem).Id_persona;
                PersonaABM form = new PersonaABM(id, ApplicationForm.ModoForm.Baja);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click  de Clase listarpersonas");
            }
        }
    }//end class
}
