using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.DataBase;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloLogic : Business.Logic.BusinessLogic
    {
        private Data.DataBase.ModuloAdapter _moduloData;

        public Data.DataBase.ModuloAdapter ModuloData
        {
            get { return _moduloData; }
            set { _moduloData = value; }
        }

        public ModuloLogic()
        {
            this._moduloData = new ModuloAdapter();
        }

        public void Delete(int id)
        {
            this._moduloData.Delete(id);
        }

        public Business.Entities.modulo GetOne(int id)
        {
            return this._moduloData.GetOne(id);
        }

        //public List<Business.Entities.modulo> GetAll()
        //{
        //    return this._moduloData.GetAll();
        //}

        public void Save(Business.Entities.modulo modulo)
        {
            //this._moduloData.Save(modulo);
        }
    }
}
