using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class InscribirseAcurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                this.loadDropDownLists();
                this.Session[Global.INSCRIPCION_ACTUAL] = new docentes_cursos();
            }
        }

        protected void loadDropDownLists() 
        {
            persona docente= (persona)this.Session[Global.PERSONA_ACTUAL];
            int id_docente = docente.id_persona;
            int id_plan = docente.id_plan;

            MateriaLogic matLogic = new MateriaLogic();
            List<materia> mats = matLogic.GetMateriasParaDictado(id_docente, id_plan);

            if (mats.Count != 0)
            {
                this.ddlMaterias.DataSource = mats;
                this.ddlMaterias.DataValueField = "id_materia";
                this.ddlMaterias.DataTextField = "desc_materia";
                this.ddlMaterias.DataBind();

                this.ddlCargos.DataSource = Enum.GetValues(typeof(persona.cargo));
                this.ddlCargos.DataBind();

                this.ddlMaterias_SelectedIndexChanged(null, null);

                this.ddlCursos.Enabled = false;
            }
            else 
            {
                this.messageArea.Text = "No hay materias disponibles para inscripción.";
                this.HiddenForm();
                return;
            }
            
        }

        private void HiddenForm()
        {
            this.lblMsg.Visible = false;
            this.Label2.Visible = false;
            this.Label3.Visible = false;
            this.Label4.Visible = false;
            this.ddlCargos.Visible = false;
            this.ddlMaterias.Visible = false;
            this.ddlCursos.Visible = false;
            this.btnAceptar.Visible = false;
        }

        protected void ddlMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_materia = Int32.Parse(this.ddlMaterias.SelectedValue);

            this.LoadDropDownListCurso(id_materia);
        }

        private void LoadDropDownListCurso(int id_materia)
        {
            this.ddlCursos.Items.Clear();
            this.ddlCursos.Enabled = false;

            CursoLogic curLogic = new CursoLogic();
            List<curso> cursos = curLogic.GetCursosParaDictado(id_materia);
            if (cursos.Count > 0 )
            {
                this.ddlCursos.DataSource = CursoLogic.getCursosExtended(cursos);
                this.ddlCursos.DataValueField = "id_curso";
                this.ddlCursos.DataTextField = "desc";
                this.ddlCursos.Enabled = true;                
            }
            this.ddlCursos.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.messageArea.Text = string.Empty;
            this.messageArea.ForeColor = System.Drawing.Color.Red;

            if (this.Validar()) 
            {
                persona docente = (persona)this.Session[Global.PERSONA_ACTUAL];
                int id_curso = Int32.Parse(this.ddlCursos.SelectedValue);

                DocenteCursoLogic logic = new DocenteCursoLogic();
                docentes_cursos inscripcion = (docentes_cursos)this.Session[Global.INSCRIPCION_ACTUAL];
                inscripcion.id_docente = docente.id_persona;
                inscripcion.id_curso = id_curso;
                inscripcion.cargo = this.ddlCargos.SelectedIndex;
                logic.save(inscripcion, "Alta");

                this.HiddenForm();
                this.messageArea.Text = "Inscripcion completada con exito.";
            }
        }

        private bool Validar() 
        {
            if ( (this.ddlMaterias.SelectedItem != null) && (this.ddlCursos.SelectedItem != null) )
            {
                return false;
            }
            this.messageArea.Text = "Por favor Seleccion una Materia y un Curso";
            this.messageArea.ForeColor = System.Drawing.Color.Green;
            return false;
        }
    }//end class
}