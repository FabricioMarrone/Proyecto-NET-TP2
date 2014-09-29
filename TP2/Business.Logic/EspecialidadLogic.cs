using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.DataBase;
using Business.Entities;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private Data.DataBase.EspecialidadAdapter _EspecialidadData;

        public Data.DataBase.EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }

        public EspecialidadLogic()
        {
            this._EspecialidadData = new EspecialidadAdapter();
        }

        public Business.Entities.especialidade GetOne(int id)
        {
            return this._EspecialidadData.GetOne(id);
        }

        public List<especialidade> GetAll()
        {
            return this._EspecialidadData.GetAll();
            //return EspecialidadAdapter.Especialidades;
        }

        //public void Save(Business.Entities.especialidade especialidad)
        //{
        //    this._EspecialidadData.Save(especialidad);
        //}

        public void Delete(int id)
        {
            this._EspecialidadData.Delete(id);
        }
    }
}
