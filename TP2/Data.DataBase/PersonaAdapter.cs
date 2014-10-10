using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class PersonaAdapter : Data.DataBase.Adapter
    {

        public persona GetOne(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Linq tipo consulta SQL
                var querySQL = (from per in academiaContext.personas
                                where per.id_persona == id
                                select per).Single();

                return querySQL;
            }
        }

        public List<persona> GetAll()
        {
            using (AcademiaEntities context = new AcademiaEntities())
            {
                var querySQL = (from per in context.personas
                                select per).ToList();
                return querySQL;
            }
        }

        public void Insert(persona per)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.personas.Add(per);
                academiaContext.SaveChanges();
            }
        }

        public void Update(persona per)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryGetOne = (from pe in academiaContext.personas
                                   where pe.id_persona == per.id_persona
                                   select pe).First();
                persona p = queryGetOne;

                p.nombre = per.nombre;
                p.apellido = per.apellido;
                p.telefono = per.telefono;
                p.email = per.email;
                p.direccion = per.direccion;
                p.fecha_nac = per.fecha_nac;
                p.legajo = per.legajo;
                p.tipo_persona = per.tipo_persona;
                p.id_plan = per.id_plan;

                academiaContext.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var query = (from per in academiaContext.personas
                             where per.id_persona == id
                             select per).First();
                academiaContext.personas.Remove(query);
                academiaContext.SaveChanges();
            }
        }

        public void Delete(persona persona)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.personas.Remove(persona);
                academiaContext.SaveChanges();
            }
        }
    }//end class
}
