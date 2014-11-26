using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class ElegirComision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                this.Session[Global.INSCRIPCION_ACTUAL] = new alumnos_inscripciones();
                MateriaLogic logic = new MateriaLogic();
                materia mat = logic.GetOne((int)this.Session[Global.ID_MATERIA_SELECCIONADA]);
                this.lblMateria.Text = mat.desc_materia;

                this.loadComisiones((int)this.Session[Global.ID_MATERIA_SELECCIONADA]);
            }
        }

        private void loadComisiones(int id_materia) 
        {
            CursoLogic cursoLogic = new CursoLogic();
            IList comisiones = cursoLogic.GetCursosParaInscripcion(id_materia);
            // Recuperar las comisiones con que tenga cupo para inscribirse.
            if (comisiones != null)
            {
                foreach (Object com in comisiones)
                {
                    string id_com= (com.GetType()).GetProperty("IdCurso").GetValue(com, null).ToString();
                    string desc= (com.GetType()).GetProperty("DescripcionComision").GetValue(com, null).ToString();
                    this.rblComisiones.Items.Add(new ListItem(desc, id_com));
                }
            }
            else
            {
                this.lblMsg.Text = "No existen comisiones con cupos disponibles para su inscripcion.";
                this.lblMateria.Visible = false;
                this.btnAceptar.Visible = false;
                return;
            }
        }

        protected bool Validar() 
        {
            if (this.rblComisiones.SelectedItem == null)
            {
                this.messageArea.Text = "Por favor seleccione una Comision.";
                return false;
            }
            return true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                int id = Int32.Parse(this.rblComisiones.SelectedValue);
                registrarInscripcion(id);
            }
        }

        protected void registrarInscripcion(int id_curso) 
        {
            persona per= (persona)this.Session[Global.PERSONA_ACTUAL];
            alumnos_inscripciones inscripcion = (alumnos_inscripciones)this.Session[Global.INSCRIPCION_ACTUAL];
            inscripcion.id_alumno = per.id_persona;
            inscripcion.condicion = alumnos_inscripciones.tipoCondicion.Inscripto.ToString();
            inscripcion.id_curso = id_curso;
            InscripcionAlumnoLogic inscLogic = new InscripcionAlumnoLogic();
            inscLogic.Save(inscripcion, "Alta");
            Response.Redirect("inscripcionAmateria.aspx?msg=yes");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/InscripcionAmateria.aspx");
        }
    }//end class
}