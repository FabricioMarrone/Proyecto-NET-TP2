using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class PlanAdapter : Data.DataBase.Adapter
    {
        private static List<Business.Entities.plane> _Planes;

        public static List<Business.Entities.plane> Planes
        {
            get { return PlanAdapter._Planes; }
            set { PlanAdapter._Planes = value; }
        }


       

        public Business.Entities.plane GetOne(int id)
        {
            return new Business.Entities.plane();
        }

        public void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }
        public void Delete(Business.Entities.plane pl) {
            Planes.Remove(pl);
        }

        //public void Save(Plan plan)
        //{
        //    switch (plan.State)
        //    {
        //        case BusinessEntity.States.New:
        //            int nuevoId = 0;
        //            // esta busqueda podria reemplazarse por un OrderBy que orden por ID.
        //            foreach (Plan pl in Planes)
        //            {
        //                if(pl.Id > nuevoId){
        //                    nuevoId = pl.Id;
        //                }
        //            }
        //            plan.Id = nuevoId + 1;
        //            Planes.Add(plan);
        //            break;
        //        case BusinessEntity.States.Modified:
        //            Planes[Planes.FindIndex(delegate(Plan p) { return p.Id == plan.Id; })] = plan;
        //            break;
        //        case BusinessEntity.States.Deleted:
        //            this.Delete(plan);
        //            break;
        //    }
        //    plan.State = BusinessEntity.States.Unmodified;

        //}


    }
}
