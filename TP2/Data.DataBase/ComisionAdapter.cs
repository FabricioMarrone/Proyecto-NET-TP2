using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class ComisionAdapter : Adapter
    {

        public comisione GetOne(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Linq tipo consulta SQL
                var querySQL = (from com in academiaContext.comisiones
                                where com.id_comision == id
                                select com).Single();

                return querySQL;
            }
        }

        public List<comisione> GetAll()
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Linq tipo consulta SQL
                var querySQL = (from com in academiaContext.comisiones
                                select com).ToList();

                return querySQL;
            }
        }

        public void Insert(comisione com)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.comisiones.Add(com);
                academiaContext.SaveChanges();
            }
        }

        public void Update(comisione com)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryGetOne = (from co in academiaContext.comisiones
                                   where co.id_comision == com.id_comision
                                   select co).First();
                comisione c = queryGetOne;

                c.id_plan = com.id_plan;
                c.desc_comision = com.desc_comision;
                c.anio_especialidad = com.anio_especialidad;
                
                academiaContext.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var query = (from com in academiaContext.comisiones
                             where com.id_comision == id
                             select com).First();
                academiaContext.comisiones.Remove(query);
                academiaContext.SaveChanges();
            }
        }

        public void Delete(comisione comision)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.comisiones.Remove(comision);
                academiaContext.SaveChanges();
            }
        }

    }
}
