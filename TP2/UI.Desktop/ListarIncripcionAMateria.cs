using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ListarIncripcionAMateria : Form
    {

             /* Esto es una solucion temporal.
             * Deberia obtener el objeto Persona de la sesion actual del usuario.
             */
        Business.Entities.persona personaActual;

        //  FUNCIONALIDAD AUN NO TERMINADA
        public enum typeColumn { TEXTBOX, CHECKBOX, COMBOBOX, BUTTON };


        public ListarIncripcionAMateria(/* persona oPersona */)
        {
            InitializeComponent();

            /* Esto es una solucion temporal.
            * Deberia obtener el objeto Persona de la sesion actual del usuario.
            */
            //this.personaActual = oPersona;
            this.personaActual = new Business.Entities.persona();
            this.personaActual.id_persona = 1; // Corresponde a Jose Garciar (en mi base de datos)
            this.personaActual.id_plan = 2; // Corresponde a Plan 2008 de ISI. (en mi base de datos)


            this.dgvMaterias.AutoGenerateColumns = false;
            this.dgvMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.GenerarColumnas();
        }

        private void GenerarColumnas() 
        {
            DataGridViewColumn dgvColum;
            dgvColum = this.CrearNuevaColumna(typeColumn.BUTTON, "btnInscripcion", "Inscribirme", null);
            this.dgvMaterias.Columns.Add(dgvColum);

            dgvColum = this.CrearNuevaColumna("semanalesMateria", "Hs Semanales", "hs_semanales");
            this.dgvMaterias.Columns.Add(dgvColum);

            dgvColum = this.CrearNuevaColumna("nombreMateria", "Materia", "desc_materia");
            this.dgvMaterias.Columns.Add(dgvColum);

            dgvColum = this.CrearNuevaColumna("idMateria", "Id", "id_materia");
            this.dgvMaterias.Columns.Add(dgvColum);

            this.dgvMaterias.CellClick += new DataGridViewCellEventHandler(dgvMaterias_CellClick);
        }


        private DataGridViewColumn CrearNuevaColumna(string name, string header, string propName)
        {
            return CrearNuevaColumna(typeColumn.TEXTBOX, name, header, propName);
        }

        /// <summary>
        /// Devuelve un tipo de DataGridViewColum listo para ser agregado al DataGridView.
        /// </summary>
        /// <param name="type">Tipo Columna Requerida</param>
        /// <param name="name">Nombre Referencia de la Columna</param>
        /// <param name="header">Titulo de la Columna</param>
        /// <param name="propName">Propiedad de Entidad Asociada a la Columna</param>
        /// <returns>DataGridVieColum</returns>
        public DataGridViewColumn CrearNuevaColumna(typeColumn type, string name, string header, string propName)
        {
            switch (type)
            {
                case typeColumn.TEXTBOX:
                    DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = name;
                    dgvc.HeaderText = header;
                    dgvc.DataPropertyName = propName;
                    dgvc.DisplayIndex = 0;
                    dgvc.ReadOnly = true;
                    return dgvc;

                case typeColumn.BUTTON:
                    DataGridViewButtonColumn dgvbc = new DataGridViewButtonColumn();
                    dgvbc.Name = name;
                    dgvbc.HeaderText = header;
                    //dgvbc.DataPropertyName = propName;
                    dgvbc.DisplayIndex = 0;
                    dgvbc.Text = header;
                    dgvbc.UseColumnTextForButtonValue = true;
                    return dgvbc;
            }

            return null;
            
        }

        public void Listar() 
        {
            try
            {
                MateriaLogic materiaLogic = new MateriaLogic();
                this.dgvMaterias.DataSource = materiaLogic.GetMateriasParaInscripcion(personaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si el evento se descencadena por una celda que no contine boton se ignora.
            if (e.ColumnIndex != this.dgvMaterias.Columns["btnInscripcion"].Index) return;
            try
            {
                materia oMateria = (materia)this.dgvMaterias.SelectedRows[0].DataBoundItem;
                InscripcionComision formInscComision = new InscripcionComision(oMateria, personaActual.id_persona);
                formInscComision.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo dgvMaterias_CellClick de Clase ListarIncripcionAMateria Form");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListarIncripcionAMateria_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
