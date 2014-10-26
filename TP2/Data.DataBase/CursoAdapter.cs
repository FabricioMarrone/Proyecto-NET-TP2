using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class CursoAdapter : Adapter
    {

        public Business.Entities.curso GetOne(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Linq tipo consulta SQL
                var querySQL = (from cur in academiaContext.cursos
                                where cur.id_curso == id
                                select cur).Single();

                return querySQL;
            }
        }

        public List<Business.Entities.curso> GetAll()
        {
            using (AcademiaEntities context = new AcademiaEntities())
            {
                //return context.especialidades.ToList<especialidade>();
                var querySQL = (from cur in context.cursos
                                select cur).ToList();
                return querySQL;
            }
        }

        public IList GetCursosParaInscripcion(int idMateria)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                IList queryCursos = (from cur in academiaContext.cursos
                                   where cur.id_materia == idMateria &&
                                         cur.cupo > 0 &&
                                         cur.anio_calendario == (DateTime.Now).Year
                                   orderby cur.comisione.desc_comision
                                   select new { 
                                       IdCurso = cur.id_curso,
                                       DescripcionComision = cur.comisione.desc_comision
                                   }).ToList();

                if (queryCursos.Count == 0) queryCursos = null;
                return queryCursos;
            }
        } 

        public void Insert(curso cur)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.cursos.Add(cur);
                academiaContext.SaveChanges();
            }
        }

        public void Update(curso cur)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryGetOne = (from cu in academiaContext.cursos
                                   where cu.id_curso == cur.id_curso
                                   select cu).First();
                curso c = queryGetOne;

                c.id_materia = cur.id_materia;
                c.id_comision = cur.id_comision;
                c.anio_calendario = cur.anio_calendario;
                c.cupo = cur.cupo;

                academiaContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var query = (from cur in academiaContext.cursos
                             where cur.id_curso == id
                             select cur).First();
                academiaContext.cursos.Remove(query);
                academiaContext.SaveChanges();
            }
        }

        public void Delete(curso curso)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.cursos.Remove(curso);
                academiaContext.SaveChanges();
            }
        }
    }
}
