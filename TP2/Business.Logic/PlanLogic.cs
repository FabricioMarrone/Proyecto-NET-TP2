using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.DataBase;
using Business.Entities;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter _planData;

        public PlanAdapter PlanData
        {
            get { return _planData; }
            set { _planData = value; }
        }

        public PlanLogic()
        {
            this.PlanData = new PlanAdapter();
        }

        public plane GetOne(int id)
        {
            return this._planData.GetOne(id);
        }

        public List<plane> GetAll()
        {
            return this.PlanData.GetAll();
        }

        public void Save(plane pl, string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this.PlanData.Insert(pl);
                    break;
                case "Baja":
                    this.PlanData.Delete(pl.id_plan);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this.PlanData.Update(pl);
                    break;
            }
        }

        public void Delete(int id)
        {
            this.PlanData.Delete(id);
        }

        public static PlanExtended getPlanExtended(plane plan)
        {
            return new PlanExtended(plan);
        }

        public static List<PlanExtended> getPlanesExtended(List<plane> planes)
        {
            List<PlanExtended> list = new List<PlanExtended>();
            foreach (plane p in planes)
            {
                list.Add(getPlanExtended(p));
            }
            return list;
        }

        public class PlanExtended 
        {
            private int id_plan;
            private string desc_plan;
            private string especialidad;
            #region propiedades
            public string Especialidad
            {
                get { return especialidad; }
                set { especialidad = value; }
            }

            public string Desc_plan
            {
                get { return desc_plan; }
                set { desc_plan = value; }
            }

            public int Id_plan
            {
                get { return id_plan; }
                set { id_plan = value; }
            }
            #endregion
            public PlanExtended(plane plan) 
            {
                this.Id_plan = plan.id_plan;
                this.Desc_plan = plan.desc_plan;
                EspecialidadLogic logic = new EspecialidadLogic();
                this.Especialidad = logic.GetOne(plan.id_especialidad).desc_especialidad;
            }
        }//end sub class

    }//end class
}
