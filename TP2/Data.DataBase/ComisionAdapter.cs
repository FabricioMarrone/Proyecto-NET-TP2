using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class ComisionAdapter : Data.DataBase.Adapter
    {
        private static List<Business.Entities.comisione> _Comisiones;

        public static List<Business.Entities.comisione> Comisiones
        {
            get { return ComisionAdapter._Comisiones; }
            set { ComisionAdapter._Comisiones = value; }
        }

        public Business.Entities.comisione GetOne(int id)
        {
            return new Business.Entities.comisione();
        }

        public List<Business.Entities.comisione> GetAll()
        {
            return new List<comisione>(Comisiones);
        }

        //public void Save(Business.Entities.comisione comision)
        //{
        //    switch (comision.State)
        //    {
        //        case BusinessEntity.States.New:
        //            int nuevoId = 0;
        //            // esta busqueda podria reemplazarse por un OrderBy que orden por ID.
        //            foreach (Comision com in Comisiones)
        //            {
        //                if (com.Id > nuevoId)
        //                {
        //                    nuevoId = com.Id;
        //                }
        //            }
        //            comision.Id = nuevoId + 1;
        //            Comisiones.Add(comision);
        //            break;
        //        case BusinessEntity.States.Modified:
        //            Comisiones[Comisiones.FindIndex(delegate(Comision c) { return c.Id == comision.Id; })] = comision;
        //            break;
        //        case BusinessEntity.States.Deleted:
        //            this.Delete(comision);
        //            break;
        //    }
        //    comision.State = BusinessEntity.States.Unmodified;
        //}

        public void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }

        public void Delete(Business.Entities.comisione comision)
        {
            Comisiones.Remove(comision);
        }

    }
}
