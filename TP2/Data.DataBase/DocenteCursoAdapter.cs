using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class DocenteCursoAdapter : Adapter
    {

        public docentes_cursos GetOne(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Linq tipo consulta SQL
                var querySQL = (from dc in academiaContext.docentes_cursos
                                where dc.id_dictado == id
                                select dc).Single();

                return querySQL;
            }
        }

        public List<docentes_cursos> GetAll()
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Linq tipo consulta SQL
                var querySQL = (from dc in academiaContext.docentes_cursos
                                select dc).ToList();

                return querySQL;
            }
        }

        public void Insert(docentes_cursos dc)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.docentes_cursos.Add(dc);
                academiaContext.SaveChanges();
            }
        }

        public void Update(docentes_cursos doc_cur)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryGetOne = (from dc in academiaContext.docentes_cursos
                                   where dc.id_dictado == doc_cur.id_dictado
                                   select dc).First();
                docentes_cursos docu = queryGetOne;

                docu.id_curso = doc_cur.id_curso;
                docu.id_docente = doc_cur.id_docente;
                docu.cargo = doc_cur.cargo;

                academiaContext.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var query = (from dc in academiaContext.docentes_cursos
                             where dc.id_dictado == id
                             select dc).First();
                academiaContext.docentes_cursos.Remove(query);
                academiaContext.SaveChanges();
            }
        }

        public void Delete(docentes_cursos docenteCurso)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.docentes_cursos.Remove(docenteCurso);
                academiaContext.SaveChanges();
            }
        }

        public List<curso> getCursosDelDocente(persona docente) 
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var querySQL = (from dc in academiaContext.docentes_cursos
                                join cur in academiaContext.cursos
                                on dc.id_curso equals cur.id_curso
                                where dc.id_docente == docente.id_persona
                                select cur).ToList();
                return querySQL;
            }
        }
    }//end class
}
