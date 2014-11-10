﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session[Global.PERSONA_ACTUAL] != null) 
            {
                persona per = (persona)this.Session[Global.PERSONA_ACTUAL];
                this.showMenu(per.tipo_persona);
            }
        }

        protected void linkMenuOption0_Click(object sender, EventArgs e)
        {
            if (this.Session[Global.USUARIO_ACTUAL] == null)
            {
                //No hay sesion iniciada
                Response.Redirect("Home.aspx");
            }
            else 
            {
                //Hay sesion iniciada y se desea "cerrar la sesion".
                this.Session[Global.USUARIO_ACTUAL] = null;
                this.Session[Global.PERSONA_ACTUAL] = null;
                this.linkMenuOption0.Text = "Iniciar sesion";
                this.linkMenuOption1.Visible = false;
                this.linkMenuOption2.Visible = false;
                this.linkMenuOption3.Visible = false;
                Response.Redirect("Home.aspx");
            }
        }

        protected void linkMenuOption1_Click(object sender, EventArgs e)
        {
            //Modificar datos (sea cual sea el tipo de persona, incluso admin)
            Response.Redirect("ModificarDatos.aspx");

        }

        protected void linkMenuOption2_Click(object sender, EventArgs e)
        {
            persona per = (persona)this.Session[Global.PERSONA_ACTUAL];
            switch (per.tipo_persona) 
            {
                case (int)persona.tipo.Alumno:
                    //Estado academico
                    Response.Redirect("EstadoAcademico.aspx");
                    break;
                case (int)persona.tipo.Admin:
                    Response.Redirect("~/Usuarios.aspx");
                    break;
                case (int)persona.tipo.Profesor:
                    //Cargar notas
                    Response.Redirect("CargarNotas.aspx");
                    break;
            }
        }

        protected void linkMenuOption3_Click(object sender, EventArgs e)
        {
            persona per = (persona)this.Session[Global.PERSONA_ACTUAL];
            switch (per.tipo_persona)
            {
                case (int)persona.tipo.Alumno:
                    //Inscripcion a materia
                    Response.Redirect("InscripcionAmateria.aspx");
                    break;
                case (int)persona.tipo.Admin:
                 
                    break;
                case (int)persona.tipo.Profesor:
                    //Inscripcion a curso
                    Response.Redirect("InscribirseAcurso.aspx");
                    break;
            }
        }

        public void showMenu(int tipo)
        {
            //LinkButton linkMenuOption1 = (LinkButton)FindControlRecursive(Master, "linkMenuOption1");
            //LinkButton linkMenuOption2 = (LinkButton)FindControlRecursive(Master, "linkMenuOption2");
            //LinkButton linkMenuOption3 = (LinkButton)FindControlRecursive(Master, "linkMenuOption3");
            linkMenuOption0.Text = "Cerrar sesión";
            linkMenuOption1.Text = "Modificar datos";
            linkMenuOption1.Visible = true;
            switch (tipo)
            {
                case (int)persona.tipo.Alumno:
                    linkMenuOption2.Text = "Estado academico";
                    linkMenuOption3.Text = "Inscripcion a materia";
                    linkMenuOption2.Visible = true;
                    linkMenuOption3.Visible = true;
                    break;
                case (int)persona.tipo.Admin:
                    linkMenuOption2.Text = "Lista de Usuarios";
                    linkMenuOption2.Visible = true;

                    linkMenuOption3.Text = "Otra Opciones de ADMIN";
                    linkMenuOption3.Visible = true;
                    
                    break;
                case (int)persona.tipo.Profesor:
                    linkMenuOption2.Text = "Cargar notas";
                    linkMenuOption3.Text = "Inscripcion a curso";
                    linkMenuOption2.Visible = true;
                    linkMenuOption3.Visible = true;
                    break;
            }//end switch
        }

        public void occultMenu()
        {
            //LinkButton linkMenuOption1 = (LinkButton)FindControlRecursive(Master, "linkMenuOption1");
            //LinkButton linkMenuOption2 = (LinkButton)FindControlRecursive(Master, "linkMenuOption2");
            //LinkButton linkMenuOption3 = (LinkButton)FindControlRecursive(Master, "linkMenuOption3");
            linkMenuOption1.Visible = false;
            linkMenuOption2.Visible = false;
            linkMenuOption3.Visible = false;
        }

       

    }//end class
}