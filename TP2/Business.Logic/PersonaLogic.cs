using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.DataBase;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter _personaData;

        public PersonaLogic() 
        {
            this._personaData = new PersonaAdapter();
        }

        public persona GetOne(int? id)
        {
            if (id == null) return null;
            else return this._personaData.GetOne(id);
        }

        public List<persona> GetAll()
        {
            return this._personaData.GetAll();
        }

        public List<persona> GetAll(persona.tipo tipo)
        {
            return this._personaData.GetAll(tipo);
        }

        public void Save(persona persona, string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this._personaData.Insert(persona);
                    break;
                case "Baja":
                    this._personaData.Delete(persona.id_persona);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this._personaData.Update(persona);
                    break;
            }
        }

        public void Delete(int id)
        {
            this._personaData.Delete(id);
        }

        public static PersonaExtended getPersonaExtended(persona per)
        {
            return new PersonaExtended(per);
        }

        public static List<PersonaExtended> getPersonasExtended(List<persona> personas)
        {
            List<PersonaExtended> list = new List<PersonaExtended>();
            foreach (persona p in personas)
            {
                list.Add(getPersonaExtended(p));
            }
            return list;
        }

        public class PersonaExtended 
        {
            private int id_persona;
            private string nombre;
            private string apellido;
            private string direccion;
            private string email;
            private string telefono;
            private DateTime fecha_nac;
            private int? legajo;
            private string tipo_persona;
            private string plan;

#region Propiedades
            public string Plan
            {
                get { return plan; }
                set { plan = value; }
            }

            public string Tipo_persona
            {
                get { return tipo_persona; }
                set { tipo_persona = value; }
            }
                
            public int? Legajo
            {
                get { return legajo; }
                set { legajo = value; }
            }

            public DateTime Fecha_nac
            {
                get { return fecha_nac; }
                set { fecha_nac = value; }
            }

            public string Telefono
            {
                get { return telefono; }
                set { telefono = value; }
            }

            public string Email
            {
                get { return email; }
                set { email = value; }
            }

            public string Direccion
            {
                get { return direccion; }
                set { direccion = value; }
            }

            public string Apellido
            {
                get { return apellido; }
                set { apellido = value; }
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public int Id_persona
            {
                get { return id_persona; }
                set { id_persona = value; }
            }
#endregion

            public PersonaExtended(persona per) 
            {
                this.Id_persona = per.id_persona;
                this.Nombre = per.nombre;
                this.Apellido = per.apellido;
                this.Direccion = per.direccion;
                this.Email = per.email;
                this.Telefono = per.telefono;
                this.Fecha_nac = per.fecha_nac;
                this.Legajo = per.legajo;
                switch(per.tipo_persona){
                    case 0: this.Tipo_persona = "Alumno"; break;
                    case 1: this.Tipo_persona = "Admin"; break;
                    case 2: this.Tipo_persona = "Profesor"; break;
                }
                
                PlanLogic logic = new PlanLogic();
                plane p = logic.GetOne(per.id_plan);
                this.Plan = p.desc_plan;

            }
        }//end sub class
    }//end class
}
