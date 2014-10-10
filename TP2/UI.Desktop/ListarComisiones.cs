﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    class ListarComisiones : ListarBase
    {

        public override void GenerarColumnas()
        {
            DataGridViewColumn dgvColumn;

            //dgvColumn = this.CrearNuevaColumna("plan", "Plan", "id_plan");
            //this.dgvListar.Columns.Add(dgvColumn);
            PlanLogic planLogic = new PlanLogic();
            dgvColumn = this.CrearNuevaColumna
                (typeColumn.COMBOBOX,"plan","Plan","id_plan","desc_plan",planLogic.GetAll());
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

        public override void Nuevo_Click(object sender, EventArgs e)
        {
            ComisionesABM form = new ComisionesABM(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        public override void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((comisione)this.dgvListar.SelectedRows[0].DataBoundItem).id_comision;
                ComisionesABM form = new ComisionesABM(id, ApplicationForm.ModoForm.Modificacion);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEditar_Click  de Clase listarcomisiones");
            }
        }

        public override void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((comisione)this.dgvListar.SelectedRows[0].DataBoundItem).id_comision;
                ComisionesABM form = new ComisionesABM(id, ApplicationForm.ModoForm.Baja);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el metodo tsbEliminar_Click  de Clase listacomisione");
            }
        }
    }//end class
}
