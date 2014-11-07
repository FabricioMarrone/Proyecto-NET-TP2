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

                //this.ddlCursos.Enabled = false;

                this.ddlCargos.DataSource = Enum.GetValues(typeof(persona.cargo));
                this.ddlCargos.DataBind();

                this.ddlMaterias_SelectedIndexChanged(null, null);
            }
            else 
            {
                this.lblMsg.Text = "No hay materias disponibles para inscripción.";
                this.Label2.Visible = false;
                this.Label3.Visible = false;
                this.Label4.Visible = false;
                this.ddlCargos.Visible = false;
                this.ddlMaterias.Visible = false;
                this.ddlCursos.Visible = false;
                return;
            }
            
        }

        protected void ddlMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Index change.')</SCRIPT>");
            int id_materia = Int32.Parse(this.ddlMaterias.SelectedValue);

            CursoLogic curLogic = new CursoLogic();
            this.ddlCursos.DataSource = CursoLogic.getCursosExtended(curLogic.GetCursosParaDictado(id_materia));

            this.ddlCursos.DataValueField = "id_curso";
            this.ddlCursos.DataTextField = "desc";
            this.ddlCursos.Enabled = true;
            this.ddlCursos.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
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
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Inscripcion completada con exito.')</SCRIPT>");
            }
        }

        private bool Validar() 
        {
            Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('NO SE ESTA VALIDANDO NADA')</SCRIPT>");
            return true;
        }
    }//end class
}