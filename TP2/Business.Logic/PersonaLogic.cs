using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.DataBase;

namespace Business.Logic
{
    public class PersonaLogic : Business.Logic.BusinessLogic
    {
        private Data.DataBase.PersonaAdapter _personaData;

        public Data.DataBase.PersonaAdapter PersonaData
        {
            get { return _personaData; }
            set { _personaData = value; }
        }

        public Business.Entities.persona GetOne(int id)
        {
            return this._personaData.GetOne(id);
        }

        //public List<Business.Entities.persona> GetAll()
        //{
        //    //return this._personaData.GetAll();
        //}

        public void Save(Business.Entities.persona persona)
        {
            //this._personaData.Save(persona);
        }

        public void Delete(int id)
        {
            this._personaData.Delete(id);
        }

    }
}
