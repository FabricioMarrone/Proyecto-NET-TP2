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
        private EspecialidadAdapter _EspecialidadData;

        public EspecialidadLogic()
        {
            this._EspecialidadData = new EspecialidadAdapter();
        }

        public especialidade GetOne(int id)
        {
            return this._EspecialidadData.GetOne(id);
        }

        public List<especialidade> GetAll()
        {
            return this._EspecialidadData.GetAll();
        }

        public void Save(especialidade especialidad, string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this._EspecialidadData.Insert(especialidad);
                    break;
                case "Baja":
                    this._EspecialidadData.Delete(especialidad.id_especialidad);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this._EspecialidadData.Update(especialidad);
                    break;
            }
           
        }

        public void Delete(int id)
        {
            this._EspecialidadData.Delete(id);
        }
    }
}
