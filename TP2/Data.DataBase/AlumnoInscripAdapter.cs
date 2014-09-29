using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class AlumnoInscripAdapter : Data.DataBase.Adapter
    {
        private static List<Business.Entities.alumnos_inscripciones> _AlumnoInscripciones;

        public static List<Business.Entities.alumnos_inscripciones> AlumnoInscripciones
        {
            get { return AlumnoInscripAdapter._AlumnoInscripciones; }
            set { AlumnoInscripAdapter._AlumnoInscripciones = value; }
        }

    
        public void Delete(int id) 
        {
            this.Delete(this.GetOne(id));
        }

        public void Delete(Business.Entities.alumnos_inscripciones alumnoinscrip)
        {
            AlumnoInscripciones.Remove(alumnoinscrip);
        }

        public Business.Entities.alumnos_inscripciones GetOne(int id)
        {
            return new Business.Entities.alumnos_inscripciones();
        }

        //public List<Business.Entities.alumnos_inscripciones> GetAll()
        //{
        //    return new List<AlumnoInscripcion>(AlumnoInscripciones);
        //}

        //public void Save(Business.Entities.alumnos_inscripciones alumInsc)
        //{
        //    switch (alumInsc.State)
        //    {
        //        case BusinessEntity.States.New:
        //            int nuevoId = 0;
        //            // esta busqueda podria reemplazarse por un OrderBy que orden por ID.
        //            foreach (AlumnoInscripcion ai in AlumnoInscripciones)
        //            {
        //                if (ai.Id > nuevoId)
        //                {
        //                    nuevoId = ai.Id;
        //                }
        //            }
        //            alumInsc.Id = nuevoId + 1;
        //            AlumnoInscripciones.Add(alumInsc);
        //            break;
        //        case BusinessEntity.States.Modified:
        //            AlumnoInscripciones[AlumnoInscripciones.FindIndex(delegate(AlumnoInscripcion ai) { return ai.Id == alumInsc.Id; })] = alumInsc;
        //            break;
        //        case BusinessEntity.States.Deleted:
        //            this.Delete(alumInsc);
        //            break;
        //    }
        //    alumInsc.State = BusinessEntity.States.Unmodified;

        //}
    }
}
