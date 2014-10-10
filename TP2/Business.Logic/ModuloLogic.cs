using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.DataBase;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        private ModuloAdapter _moduloData;

        public ModuloAdapter ModuloData
        {
            get { return _moduloData; }
            set { _moduloData = value; }
        }

        public ModuloLogic()
        {
            this._moduloData = new ModuloAdapter();
        }

        public modulo GetOne(int id)
        {
            return this._moduloData.GetOne(id);
        }

        public List<modulo> GetAll()
        {
            return this._moduloData.GetAll();
        }

        public void Save(modulo modulo, string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this._moduloData.Insert(modulo);
                    break;
                case "Baja":
                    this._moduloData.Delete(modulo.id_modulo);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this._moduloData.Update(modulo);
                    break;
            }
        }

        public void Delete(int id)
        {
            this._moduloData.Delete(id);
        }
    }//end class
}
