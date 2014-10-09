using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class PlanAdapter : Adapter
    {
        public plane GetOne(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryPlan = (from pl in academiaContext.planes
                                 where pl.id_plan == id
                                 select pl).First();
                return queryPlan;
            }
        }

        public List<plane> GetAll()
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryPlanes = (from pl in academiaContext.planes
                                   select pl).ToList();
                return queryPlanes;
            }
        }

        public void Insert(plane pl)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.planes.Add(pl);
                academiaContext.SaveChanges();
            }
        }

        public void Update(plane plan)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryGetOne = (from pl in academiaContext.planes
                                   where pl.id_plan == plan.id_plan
                                   select pl).First();
                plane p = queryGetOne;

                p.id_plan = plan.id_plan;
                p.desc_plan = plan.desc_plan;
                p.id_especialidad = plan.id_especialidad;

                academiaContext.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var query = (from pl in academiaContext.planes
                             where pl.id_plan == id
                             select pl).First();
                academiaContext.planes.Remove(query);
                academiaContext.SaveChanges();
            }
        }

        public void Delete(plane pl) {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.planes.Remove(pl);
                academiaContext.SaveChanges();
            }
        }

    }
}
