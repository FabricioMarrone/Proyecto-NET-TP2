﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    class ListarPersonas : ListarBase
    {
        public ListarPersonas()
            : base()
        {
            this.Text = "Listado de Personas";
            this.Width = this.Width + 300;
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

            dgvColum = ListarBase.CrearNuevaColumna("legajo", "legajo", "legajo");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("fechaNac", "Fecha Nacimiento", "fecha_nac");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("telefono", "telefono", "telefono");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("email", "Email", "email");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("direccion", "Direccion", "direccion");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("apellido", "Apellido", "apellido");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("nombre", "Nombre", "nombre");
            this.dgvListar.Columns.Add(dgvColum);

            dgvColum = ListarBase.CrearNuevaColumna("id_persona", "ID", "id_persona");
            this.dgvListar.Columns.Add(dgvColum);
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
