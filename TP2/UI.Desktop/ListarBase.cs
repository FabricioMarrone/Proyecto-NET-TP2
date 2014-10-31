using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public abstract partial class ListarBase : Form
    {
        public enum typeColumn {TEXTBOX,CHECKBOX,COMBOBOX, BUTTON};

        public ListarBase()
        {
            InitializeComponent();
            this.dgvListar.AutoGenerateColumns = false;
            this.dgvListar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.GenerarColumnas();
        }

        public static DataGridViewColumn CrearNuevaColumna(string name, string header, string propName)
        {
            return CrearNuevaColumna(typeColumn.TEXTBOX, name, header, propName, null, null);
        }

        public static DataGridViewColumn CrearNuevaColumna(typeColumn type, string name, string header, string propName)
        {
            return CrearNuevaColumna(type, name, header, propName, null, null);
        }

        /// <summary>
        /// Devuelve un tipo de DataGridViewColum listo para ser agregado al DataGridView.
        /// </summary>
        /// <param name="type">Tipo Columna Requerida</param>
        /// <param name="name">Nombre Referencia de la Columna</param>
        /// <param name="header">Titulo de la Columna</param>
        /// <param name="propName">Propiedad de Entidad Asociada a la Columna</param>
        /// <param name="descEntity">Valor a mostrar en ComboBox</param>
        /// <param name="source">Origen de Datos para CombosBox</param>
        /// <returns>DataGridVieColum</returns>
        public static DataGridViewColumn CrearNuevaColumna(typeColumn type, string name, string header, string propName, string descEntity, System.Collections.IList source)
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
                    DataGridViewComboBoxColumn dgvcbxc = new DataGridViewComboBoxColumn();
                    dgvcbxc.DataSource = source;
                    //dgvcbxc.ValueMember = propName;
                    //dgvcbxc.DisplayMember = descEntity;
                    dgvc = (DataGridViewColumn)dgvcbxc;
                    break;

                case typeColumn.BUTTON:
                    DataGridViewButtonColumn dgvbc = new DataGridViewButtonColumn();
                    dgvbc.Text = header;
                    dgvbc.UseColumnTextForButtonValue = true;
                    dgvc = (DataGridViewColumn)dgvbc;
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

        public void ListarBase_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public abstract void GenerarColumnas();

        public abstract void Listar();

        public void tsbNuevo_Click(object sender, EventArgs e)
        {
            this.Nuevo_Click(sender, e);
        }

        public void tsbEditar_Click(object sender, EventArgs e) 
        {
            this.Editar_Click(sender, e);
        }

        public void tsbEliminar_Click(object sender, EventArgs e) 
        {
            this.Eliminar_Click(sender, e);
        }

        public abstract void Nuevo_Click(object sender, EventArgs e);

        public abstract void Editar_Click(object sender, EventArgs e);

        public abstract void Eliminar_Click(object sender, EventArgs e);

    }//end class
}
