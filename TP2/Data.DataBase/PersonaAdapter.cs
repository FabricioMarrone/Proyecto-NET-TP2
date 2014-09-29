using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class PersonaAdapter : Data.DataBase.Adapter
    {
        private static List<Business.Entities.persona> _Personas;

        public static List<Business.Entities.persona> Personas
        {
            get { return PersonaAdapter._Personas; }
            set { PersonaAdapter._Personas = value; }
        }

        public persona GetOne(int id)
        {
            return new Business.Entities.persona();
        }

        //public List<persona> GetAll()
        //{
        //    return new List<persona>(Personas);
        //}

        //public void Save(persona persona)
        //{
        //    switch (persona.State)
        //    {
        //        case BusinessEntity.States.New:
        //            int nuevoId = 0;
        //            // esta busqueda podria reemplazarse por un OrderBy que orden por ID.
        //            foreach (Persona per in Personas)
        //            {
        //                if (per.Id > nuevoId)
        //                {
        //                    nuevoId = per.Id;
        //                }
        //            }
        //            persona.Id = nuevoId + 1;
        //            Personas.Add(persona);
        //            break;
        //        case BusinessEntity.States.Modified:
        //            Personas[Personas.FindIndex(delegate(Persona p) { return p.Id == persona.Id; })] = persona;
        //            break;
        //        case BusinessEntity.States.Deleted:
        //            this.Delete(persona);
        //            break;
        //    }
        //    persona.State = BusinessEntity.States.Unmodified;
        //}

        public void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }

        public void Delete(Business.Entities.persona persona)
        {
            Personas.Remove(persona);
        }
    }
}
