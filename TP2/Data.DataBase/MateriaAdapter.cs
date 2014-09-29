using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class MateriaAdapter : Data.DataBase.Adapter
    {
        private static List<Business.Entities.materia> _Materias;

        public static List<Business.Entities.materia> Materias
        {
            get { return MateriaAdapter._Materias; }
            set { MateriaAdapter._Materias = value; }
        }


        public Business.Entities.materia GetOne(int id)
        {
            return new Business.Entities.materia();
        }

        //public List<Materia> GetAll()
        //{
        //    return new List<Materia>(Materias);
        //}

        //public void Save(Business.Entities.materia materia)
        //{
        //    switch (materia.State)
        //    {
        //        case BusinessEntity.States.New:
        //            int nuevoId = 0;
        //            // esta busqueda podria reemplazarse por un OrderBy que orden por ID.
        //            foreach (Materia per in Materias)
        //            {
        //                if (per.Id > nuevoId)
        //                {
        //                    nuevoId = per.Id;
        //                }
        //            }
        //            materia.Id = nuevoId + 1;
        //            Materias.Add(materia);
        //            break;
        //        case BusinessEntity.States.Modified:
        //            Materias[Materias.FindIndex(delegate(Materia m) { return m.Id == materia.Id; })] = materia;
        //            break;
        //        case BusinessEntity.States.Deleted:
        //            this.Delete(materia);
        //            break;
        //    }
        //    materia.State = BusinessEntity.States.Unmodified;
        //}

        public void Delete(Business.Entities.materia materia)
        {
            _Materias.Remove(materia);
        }

        public void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }
    }
}
