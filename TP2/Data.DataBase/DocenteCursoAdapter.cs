using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class DocenteCursoAdapter : Data.DataBase.Adapter
    {
        private static List<Business.Entities.docentes_cursos> _DocenteCursos;

        public static List<Business.Entities.docentes_cursos> DocenteCursos
        {
            get { return DocenteCursoAdapter._DocenteCursos; }
            set { DocenteCursoAdapter._DocenteCursos = value; }
        }

        public Business.Entities.docentes_cursos GetOne(int id)
        {
            return new Business.Entities.docentes_cursos();
        }

        //public List<Business.Entities.docentes_cursos> GetAll()
        //{
        //    return new List<DocenteCurso>(DocenteCursos);
        //}

        //public void Save(Business.Entities.docentes_cursos docenteCurso)
        //{
        //    switch (docenteCurso.State)
        //    {
        //        case BusinessEntity.States.New:
        //            int nuevoId = 0;
        //            // esta busqueda podria reemplazarse por un OrderBy que orden por ID.
        //            foreach (DocenteCurso dc in DocenteCursos)
        //            {
        //                if (dc.Id > nuevoId)
        //                {
        //                    nuevoId = dc.Id;
        //                }
        //            }
        //            docenteCurso.Id = nuevoId + 1;
        //            DocenteCursos.Add(docenteCurso);
        //            break;
        //        case BusinessEntity.States.Modified:
        //            DocenteCursos[DocenteCursos.FindIndex(delegate(DocenteCurso dc) { return dc.Id == docenteCurso.Id; })] = docenteCurso;
        //            break;
        //        case BusinessEntity.States.Deleted:
        //            this.Delete(docenteCurso);
        //            break;
        //    }
        //    docenteCurso.State = BusinessEntity.States.Unmodified;            
        //}

        public void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }

        public void Delete(Business.Entities.docentes_cursos docenteCurso)
        {
            DocenteCursos.Remove(docenteCurso);
        }

    }
}
