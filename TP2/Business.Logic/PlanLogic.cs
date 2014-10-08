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
        private Data.DataBase.PlanAdapter _planData;

        public Data.DataBase.PlanAdapter PlanData
        {
            get { return _planData; }
            set { _planData = value; }
        }

        public PlanLogic()
        {
            this.PlanData = new PlanAdapter();
        }

        public Business.Entities.plane GetOne(int id)
        {
            return this._planData.GetOne(id);
        }

        public List<Business.Entities.plane> GetAll()
        {
            return this.PlanData.GetAll();
        }

        public void Save(Business.Entities.plane pl)
        {
            //this.PlanData.Save(pl);
        }

        public void Delete(int id)
        {
            this.PlanData.Delete(id);
        }
    }
}
