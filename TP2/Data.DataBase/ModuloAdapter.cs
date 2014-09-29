using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class ModuloAdapter : Data.DataBase.Adapter
    {
        private static List<modulo> _Modulos;

        public static List<modulo> Modulos
        {
            get { return ModuloAdapter._Modulos; }
            set { ModuloAdapter._Modulos = value; }
        }

        public Business.Entities.modulo GetOne(int id)
        {
            return new Business.Entities.modulo();
        }

        //public List<Business.Entities.modulo> GetAll()
        //{
        //    return new List<Modulo>(Modulos);
        //}

        //public void Save(Business.Entities.modulo modulo)
        //{
        //    switch (modulo.State)
        //    {
        //        case BusinessEntity.States.New:
        //            Modulos.Add(modulo);
        //            break;
        //        case BusinessEntity.States.Modified:
        //            //Aca no se que mierda hacer, no tiene ID.
        //            Modulos[Modulos.FindIndex(delegate(Modulo m) { return m.Id == modulo.Id; })] = modulo;
        //            break;
        //        case BusinessEntity.States.Deleted:
        //            this.Delete(modulo);
        //            break;
        //    }
        //    modulo.State = BusinessEntity.States.Unmodified;
        //}

        public void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }
        public void Delete(Business.Entities.modulo mod) {
            Modulos.Remove(mod);
        }
    }
}
