using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class ListarEspecialidades : UI.Desktop.ListarBase
    {
        public ListarEspecialidades()
        {
            InitializeComponent();
            //Cambia el Modifiers de los controles.
            this.GenerarColumnas();

            this.listar();
        }

        protected override void GenerarColumnas()
        {
            DataGridViewColumn dgvColum;
            dgvColum = this.CrearNuevaColumna("especialidad", "Especialidad", "desc_especialidad");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = this.CrearNuevaColumna("id", "ID", "id_especialidad");
            this.dgvListar.Columns.Add(dgvColum);
        }

        public void listar() { 
            EspecialidadLogic logic= new EspecialidadLogic();
            this.dgvListar.DataSource = logic.GetAll();
        }
    }
}
