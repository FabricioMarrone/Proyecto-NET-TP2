using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class EspecialidadAdapter : Adapter
    {
        private static List<especialidade> _Especialidades;

        public static List<especialidade> Especialidades
        {
            get { return EspecialidadAdapter._Especialidades; }
            set { EspecialidadAdapter._Especialidades = value; }
        }

        public Business.Entities.especialidade GetOne(int id)
        {
            return new Business.Entities.especialidade();
        }

        public List<especialidade> GetAll()
        {
            using(AcademiaEntities context= new AcademiaEntities()){
                //return context.especialidades.ToList<especialidade>();
                var querySQL = (from esp in context.especialidades
                                select esp).ToList();
                return querySQL;
            }
        }

        //public void Save(especialidade especialidad)
        //{
        //    switch (especialidad.State)
        //    {
        //        case BusinessEntity.States.New:
        //            Especialidades.Add(especialidad);
        //            break;
        //        case BusinessEntity.States.Modified:
        //            Especialidades[Especialidades.FindIndex(delegate(Especialidad e) { return e.Id == especialidad.Id; })] = especialidad;
        //            break;
        //        case BusinessEntity.States.Deleted:
        //            this.Delete(especialidad);
        //            break;
        //    }
        //    especialidad.State = BusinessEntity.States.Unmodified;
        //}

        public void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }

        public void Delete(especialidade especialidad)
        {
            Especialidades.Remove(especialidad);
        }
    }
}
