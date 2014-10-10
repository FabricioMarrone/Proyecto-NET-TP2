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
    }
}
