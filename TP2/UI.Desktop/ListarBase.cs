using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ListarBase : Form
    {
        public enum typeColumn {TEXTBOX,CHECKBOX,COMBOBOX};

        public ListarBase()
        {
            InitializeComponent();
            this.dgvListar.AutoGenerateColumns = false;
        }

        protected virtual void GenerarColumnas()
        {
            // Se implemente en la subclase heredada.
        }

        protected DataGridViewColumn CrearNuevaColumna(string name, string header, string propName)
        {
            return CrearNuevaColumna(typeColumn.TEXTBOX, name, header, propName);
        }

        /// <summary>
        /// Devuelve un tipo de DataGridViewColum listo para ser agregado al DataGridView.
        /// </summary>
        /// <param name="type">TipoDeColumnaRequerida</param>
        /// <param name="name">NombreDeReferenciaDeLaColumna</param>
        /// <param name="header">TituloDeLaColumna</param>
        /// <param name="propName">propiedadDeUnEntityAsociadaALaColumna</param>
        /// <returns></returns>
        protected DataGridViewColumn CrearNuevaColumna(typeColumn type, string name, string header, string propName)
        {
            DataGridViewColumn dgvc;
            switch (type)
            {
                case typeColumn.TEXTBOX:
                    dgvc = new DataGridViewTextBoxColumn();
                    break;
                case typeColumn.CHECKBOX:
                    dgvc = new DataGridViewCheckBoxColumn();
                    break;
                case typeColumn.COMBOBOX:
                    dgvc = new DataGridViewComboBoxColumn();
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

        public virtual void Listar()
        {
            // Se implementa en la subclase heredada.
        }

        private void ListarBase_Load(object sender, EventArgs e)
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

    }
}
