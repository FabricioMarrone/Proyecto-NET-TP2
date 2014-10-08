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
        private ComisionAdapter _comisionData;

        public ComisionLogic()
        {
            this._comisionData = new ComisionAdapter();
        }

        public ComisionAdapter ComisionData
        {
            get { return _comisionData; }
            set { _comisionData = value; }
        }

        public comisione GetOne(int id)
        {
            return this._comisionData.GetOne(id); 
        }

        public List<comisione> GetAll()
        {
            return this._comisionData.GetAll();
        }

        public void Save(comisione comision, string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this.ComisionData.Insert(comision);
                    break;
                case "Baja":
                    this.ComisionData.Delete(comision.id_comision);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this.ComisionData.Update(comision);
                    break;
            }
        }

        public void Delete(int id)
        {
            this._comisionData.Delete(id);
        }
    }
}
