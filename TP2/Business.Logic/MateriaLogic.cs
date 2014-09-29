using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.DataBase;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private Data.DataBase.MateriaAdapter _materiaData;

        public Data.DataBase.MateriaAdapter MateriaData
        {
            get { return _materiaData; }
            set { _materiaData = value; }
        }

        public MateriaLogic()
        {
            this._materiaData = new MateriaAdapter();
        }

        public Business.Entities.materia GetOne(int id)
        {
            return this._materiaData.GetOne(id);
        }

        //public List<Business.Entities.materia> GetAll()
        //{
        //    return this._materiaData.GetAll();
        //}

        //public void Save(Business.Entities.materia materia)
        //{
        //    this._materiaData.Save(materia);
        //}

        public void Delete(int id)
        {
            this._materiaData.Delete(id);
        }

    }
}
