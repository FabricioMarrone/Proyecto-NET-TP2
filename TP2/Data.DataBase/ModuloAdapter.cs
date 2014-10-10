using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class ModuloAdapter : Adapter
    {

        public modulo GetOne(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Linq tipo consulta SQL
                var querySQL = (from mod in academiaContext.modulos
                                where mod.id_modulo == id
                                select mod).Single();

                return querySQL;
            }
        }

        public List<modulo> GetAll()
        {
            using (AcademiaEntities context = new AcademiaEntities())
            {
                //return context.especialidades.ToList<especialidade>();
                var querySQL = (from mod in context.modulos
                                select mod).ToList();
                return querySQL;
            }
        }

        public void Insert(modulo mod)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.modulos.Add(mod);
                academiaContext.SaveChanges();
            }
        }

        public void Update(modulo mod)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryGetOne = (from mo in academiaContext.modulos
                                   where mo.id_modulo == mod.id_modulo
                                   select mo).First();
                modulo m = queryGetOne;

                m.desc_modulo = mod.desc_modulo;
                m.ejecuta = mod.ejecuta;

                academiaContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var query = (from mod in academiaContext.modulos
                             where mod.id_modulo == id
                             select mod).First();
                academiaContext.modulos.Remove(query);
                academiaContext.SaveChanges();
            }
        }

        public void Delete(modulo mod) {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.modulos.Remove(mod);
                academiaContext.SaveChanges();
            }
        }
    }//end class
}
