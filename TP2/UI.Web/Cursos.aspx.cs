using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Web
{
    public partial class Cursos : ListarABMBase
    {
        #region Prop y Vars
        private CursoLogic _curLogic;

        private CursoLogic CurLogic
        {
            get
            {
                if (this._curLogic == null) this._curLogic = new CursoLogic();
                return this._curLogic;
            }
        }

        public curso entity { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if ( !IsPostBack)
            {
                base.Page_Load(sender, e);
                this.CargarDropDownListMateria();
                this.CargarDropDownListComision();
            }
        }


        #region metodos para Implementar en clase derivada
        protected override void LoadGrid()
        {
            try
            {
                this.gvListar.DataSource = CursoLogic.getCursosExtended(this.CurLogic.GetAll());
                this.gvListar.DataBind();
                this.gvListar.SelectedIndex = -1;
            }
            catch (Exception ex) // Habria que declrar exception Propia que indique que la lista esta vacia.
            {
                this.gridPanel.Visible = false;

                this.messageArea.ForeColor = System.Drawing.Color.Red;
                this.messageArea.Text = "No existen Cursos para mostrar. " + ex.Message;
            }
        }

        protected override void mapearDeDatos(int id)
        {
            curso com = this.CurLogic.GetOne(id);
            this.IdCursoTextBox.Text = com.id_curso.ToString();
            this.mtvAnioCalendario.Text = com.anio_calendario.ToString();
            this.mtvCupo.Text = com.cupo.ToString();

            // Drop Down Lists
            this.ddlMateria.SelectedValue = com.id_materia.ToString();            
            this.ddlComision.SelectedValue = com.id_comision.ToString();
        }

        private void CargarDropDownListMateria()
        {
            MateriaLogic matLogic = new MateriaLogic();
            List<materia> mats = matLogic.GetAll();
            if (mats.Count > 0)
            {
                this.ddlMateria.DataSource = mats;
                this.ddlMateria.DataValueField = "id_materia";
                this.ddlMateria.DataTextField = "desc_materia";
                this.ddlMateria.DataBind();
            }
            else
            {
                this.messageArea.ForeColor = System.Drawing.Color.Red;
                this.messageArea.Text = "No existen Materias para realizar la creacion del Curso. ";
            }
        }

        private void CargarDropDownListComision()
        {
            ComisionLogic comisionLogic = new ComisionLogic();
            List<comisione> coms = comisionLogic.GetAll();
            if (coms.Count > 0)
            {
                this.ddlComision.DataSource = coms;
                this.ddlComision.DataValueField = "id_comision";
                this.ddlComision.DataTextField = "desc_comision";
                this.ddlComision.DataBind();
            }
            else
            {
                this.messageArea.ForeColor = System.Drawing.Color.Red;
                this.messageArea.Text = "No existen Comisiones para realizar la creacion del Curso. ";
            }
        }


        protected void LoadEntity(curso entity)
        {
            entity.anio_calendario = Int32.Parse(this.mtvAnioCalendario.Text);
            entity.cupo = Int32.Parse(this.mtvCupo.Text);
            // Drop Down Lists
            entity.id_materia = Int32.Parse(this.ddlMateria.SelectedValue);
            entity.id_comision = Int32.Parse(this.ddlComision.SelectedValue);
        }

        protected override void CargarExpresionesRegulares()
        {
            this.mtvAnioCalendario.ValidationExpression = Validador.ExpreAnio;
            this.mtvCupo.ValidationExpression = Validador.ExpreEnteroPositivo;
        }

        protected override void ClearForm()
        {
            this.IdCursoTextBox.Text = string.Empty;
            this.mtvAnioCalendario.Text = string.Empty;
            this.mtvCupo.Text = string.Empty;

            // Drop Down Lists
            this.ddlMateria.ClearSelection();
            this.ddlComision.ClearSelection();
        }

        protected override void EnableForm(bool enable)
        {
            this.IdCursoTextBox.Enabled = enable;
            this.mtvAnioCalendario.Enabled = enable;
            this.mtvCupo.Enabled = enable;
            // Drop Down Lists
            this.ddlMateria.Enabled = enable;
            this.ddlComision.Enabled = enable;
        }

        protected override void GuardarCambios()
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.entity = new curso();
                    this.LoadEntity(this.entity);
                    this.CurLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.CurLogic.Delete(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.entity = new curso();
                    this.entity.id_curso = this.SelectedID;
                    this.LoadEntity(this.entity);
                    this.CurLogic.Save(this.entity, this.FormMode.ToString());
                    this.LoadGrid();
                    break;
            }
            // Al final se seatea el SelectedID en 0 para que no mantenga el valor
            // de una anterior seleccion.
            this.SelectedID = 0;
        }
        #endregion


        #region manejadores de eventos
        protected void gvListar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvListar.SelectedValue;
        }

        protected void NuevoLinkButton_Click1(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.ClearForm();
            this.FormMode = FormModes.Alta;
            this.EnableForm(true);
        }

        protected void EditarLinkButton_Click1(object sender, EventArgs e)
        {
            if (this.isEntitySelected)// Valido que haya alguna fila seleccionada
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
            }
        }

        protected void EliminarLinkButton_Click1(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void AceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.GuardarCambios();
                this.formPanel.Visible = false;
            }
        }

        protected void CancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.LoadGrid();
            this.SelectedID = 0;
        }
        #endregion

    }
}