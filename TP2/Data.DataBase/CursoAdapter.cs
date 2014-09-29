using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class CursoAdapter : Data.DataBase.Adapter
    {
        private static List<Business.Entities.curso> _Cursos;

        public static List<Business.Entities.curso> Cursos
        {
            get { return CursoAdapter._Cursos; }
            set { CursoAdapter._Cursos = value; }
        }


        public Business.Entities.curso GetOne(int id)
        {
            return new Business.Entities.curso();
        }

        //public List<Business.Entities.curso> GetAll()
        //{
        //    return new List<Curso>(Cursos);
        //}

        //public void Save(Business.Entities.curso curso)
        //{
        //    switch (curso.State)
        //    {
        //        case BusinessEntity.States.New:
        //            int nuevoId = 0;
        //            // esta busqueda podria reemplazarse por un OrderBy que orden por ID.
        //            foreach (Curso c in Cursos)
        //            {
        //                if (c.Id > nuevoId)
        //                {
        //                    nuevoId = c.Id;
        //                }
        //            }
        //            curso.Id = nuevoId + 1;
        //            Cursos.Add(curso);
        //            break;
        //        case BusinessEntity.States.Modified:
        //            Cursos[Cursos.FindIndex(delegate(Curso c) { return c.Id == curso.Id; })] = curso;
        //            break;
        //        case BusinessEntity.States.Deleted:
        //            this.Delete(curso);
        //            break;
        //    }
        //    curso.State = BusinessEntity.States.Unmodified;
        //}

        public void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }

        public void Delete(Business.Entities.curso curso)
        {
            Cursos.Remove(curso);
        }
    }
}
