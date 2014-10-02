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

            //this.listar();
        }

        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColum;
            dgvColum = this.CrearNuevaColumna("especialidad", "Especialidad", "desc_especialidad");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = this.CrearNuevaColumna("id", "ID", "id_especialidad");
            this.dgvListar.Columns.Add(dgvColum);
        }

        public override void Listar()
        {
            EspecialidadLogic logic = new EspecialidadLogic();
            this.dgvListar.DataSource = logic.GetAll();
        }

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
           

        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
