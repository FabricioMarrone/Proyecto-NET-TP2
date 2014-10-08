using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.DataBase;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private Data.DataBase.ComisionAdapter _comisionData;

        public ComisionLogic()
        {
            this._comisionData = new ComisionAdapter();
        }

        public Data.DataBase.ComisionAdapter ComisionData
        {
            get { return _comisionData; }
            set { _comisionData = value; }
        }

        public Business.Entities.comisione GetOne(int id)
        {
            return this._comisionData.GetOne(id); 
        }

        public List<Business.Entities.comisione> GetAll()
        {
            return this._comisionData.GetAll();
        }

        //public void Save(Business.Entities.comisione comision)
        //{
        //    this._comisionData.Save(comision);
        //}

        public void Delete(int id)
        {
            this._comisionData.Delete(id);
        }
    }
}
