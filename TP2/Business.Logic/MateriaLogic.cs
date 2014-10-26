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
            return this.MateriaData.GetOne(id);
        }

        public List<Business.Entities.materia> GetAll()
        {
            return this.MateriaData.GetAll();
        }

        public List<Business.Entities.materia> GetMateriasParaInscripcion(persona oPersona)
        {
            return this.MateriaData.GetMateriasParaInscripcion(oPersona);
        }

        public void Save(Business.Entities.materia oMateria,string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this.MateriaData.Insert(oMateria);
                    break;
                case "Baja":
                    this.MateriaData.Delete(oMateria.id_materia);
                    break;
                case "Modificacion":
                    this.MateriaData.Update(oMateria);
                    break;
            }
        }

    }
}
