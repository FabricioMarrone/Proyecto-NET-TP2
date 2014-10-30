using System;
using System.Collections;
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

        private persona personaActual;

        public ListarIncripcionAMateria( persona oPersona)
        {
            InitializeComponent();

            this.personaActual = oPersona;
            
            this.dgvMaterias.AutoGenerateColumns = false;
            this.dgvMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.GenerarColumnas();
        }

        private void GenerarColumnas() 
        {
            DataGridViewColumn dgvColum;
            dgvColum = ListarBase.CrearNuevaColumna(ListarBase.typeColumn.BUTTON, "btnInscripcion", "Inscribirme", null);
            this.dgvMaterias.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("semanalesMateria", "Hs Semanales", "hs_semanales");
            this.dgvMaterias.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("nombreMateria", "Materia", "desc_materia");
            this.dgvMaterias.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("idMateria", "Id", "id_materia");
            this.dgvMaterias.Columns.Add(dgvColum);

            this.dgvMaterias.CellClick += new DataGridViewCellEventHandler(dgvMaterias_CellClick);
        }


       
        public void Listar() 
        {
            try
            {
                MateriaLogic materiaLogic = new MateriaLogic();
                IList mats = materiaLogic.GetMateriasParaInscripcion(personaActual);
                if (mats.Count == 0)
                {
                    MessageBox.Show("No hay materias disponibles para inscripción.");
                    this.Close();
                }

                this.dgvMaterias.DataSource = mats;
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
                MessageBox.Show("Inscripción exitosa!");
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
