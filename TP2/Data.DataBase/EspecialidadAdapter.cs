using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class EspecialidadAdapter : Adapter
    {

        public especialidade GetOne(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Linq tipo consulta SQL
                var querySQL = (from esp in academiaContext.especialidades
                                where esp.id_especialidad == id
                                select esp).Single();

                return querySQL;
            }
        }

        public List<especialidade> GetAll()
        {
            using(AcademiaEntities context= new AcademiaEntities()){
                var querySQL = (from esp in context.especialidades
                                select esp).ToList();
                return querySQL;
            }
        }

        public void Insert(especialidade esp)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.especialidades.Add(esp);
                academiaContext.SaveChanges();
            }
        }

        public void Update(especialidade esp)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryGetOne = (from es in academiaContext.especialidades
                                   where es.id_especialidad == esp.id_especialidad
                                   select es).First();
                especialidade e = queryGetOne;

                e.desc_especialidad = esp.desc_especialidad;

                academiaContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var query = (from esp in academiaContext.especialidades
                             where esp.id_especialidad == id
                             select esp).First();
                academiaContext.especialidades.Remove(query);
                academiaContext.SaveChanges();
            }
        }

        public void Delete(especialidade especialidad)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.especialidades.Remove(especialidad);
                academiaContext.SaveChanges();
            }
        }
    }
}
