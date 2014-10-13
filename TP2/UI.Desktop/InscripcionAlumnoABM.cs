using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class InscripcionAlumnoABM : ApplicationForm
    {
        private alumnos_inscripciones _inscripcionAlumnoActual;

        public InscripcionAlumnoABM()
        {
            InitializeComponent();
            this.loadComboBoxes();
        }

        public InscripcionAlumnoABM(ModoForm modo) : this() 
        {
            this.Modo = modo;
            this._inscripcionAlumnoActual = new alumnos_inscripciones();
        }

        public InscripcionAlumnoABM(int id, ModoForm modo) : this() 
        {
            this.Modo = modo;
            InscripcionAlumnoLogic logic = new InscripcionAlumnoLogic();
            this._inscripcionAlumnoActual = logic.GetOne(id);
            this.MapearDeDatos();
        }

        public InscripcionAlumnoABM(persona per, ModoForm modo) : this() 
        {
            this.Modo = modo;
            this._inscripcionAlumnoActual = new alumnos_inscripciones();
            
            this._inscripcionAlumnoActual.id_alumno = per.id_persona;
            this.cbAlumnos.Enabled = false;
        }

        private void loadComboBoxes()
        {
            PersonaLogic perLogic = new PersonaLogic();
            this.cbAlumnos.DataSource = perLogic.GetAll(persona.tipo.Alumno);
            this.cbAlumnos.ValueMember = "id_persona";
            this.cbAlumnos.DisplayMember = "apellido";

            CursoLogic curLogic = new CursoLogic();
            this.cbCursos.DataSource = curLogic.GetAll();
            this.cbCursos.ValueMember = "id_curso";
            this.cbCursos.DisplayMember = "id_curso";
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this._inscripcionAlumnoActual.id_inscripcion.ToString();
            this.cbAlumnos.SelectedValue = this._inscripcionAlumnoActual.id_alumno;
            this.cbCursos.SelectedValue = this._inscripcionAlumnoActual.id_curso;
            this.txtCondicion.Text = this._inscripcionAlumnoActual.condicion;
            this.txtNota.Text = this._inscripcionAlumnoActual.nota.ToString();

            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";

                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.cbAlumnos.Enabled = false;
                    this.cbCursos.Enabled = false;
                    this.txtCondicion.Enabled = false;
                    this.txtNota.Enabled = false;
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";

                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        public override bool Validar()
        {

            this.Notificar("Atencion", "No se esta validando el formulario (InscripcionAlumnoABM)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            InscripcionAlumnoLogic logic = new InscripcionAlumnoLogic();
            logic.Save(this._inscripcionAlumnoActual, this.Modo.ToString());
        }

        public override void MapearADatos()
        {
            this._inscripcionAlumnoActual.id_alumno = (int)this.cbAlumnos.SelectedValue;
            this._inscripcionAlumnoActual.id_curso = (int)this.cbCursos.SelectedValue;
            this._inscripcionAlumnoActual.condicion = this.txtCondicion.Text;
            if (this.txtNota.Text == "") this._inscripcionAlumnoActual.nota = null;
            else Int32.Parse(this.txtNota.Text);
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end class
}
