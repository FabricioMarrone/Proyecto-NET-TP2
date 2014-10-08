using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Logic;

namespace UI.Desktop
{
    public partial class ListarComisiones : UI.Desktop.ListarBase
    {
        public ListarComisiones()
        {
            InitializeComponent();
            this.GenerarColumnas();
            this.Listar();
        }

        public override void GenerarColumnas(){
            DataGridViewColumn dgvColumn;

            dgvColumn = this.CrearNuevaColumna("plan", "Plan", "id_plan");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = this.CrearNuevaColumna("anio", "Año", "anio_especialidad");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = this.CrearNuevaColumna("comision", "Comision", "desc_comision");
            this.dgvListar.Columns.Add(dgvColumn);

            dgvColumn = this.CrearNuevaColumna("id", "ID", "id_comision");
            this.dgvListar.Columns.Add(dgvColumn);
        }

        public override void Listar()
        {
            ComisionLogic comisionesLogic = new ComisionLogic();
            this.dgvListar.DataSource = comisionesLogic.GetAll();
        }

    }
}
