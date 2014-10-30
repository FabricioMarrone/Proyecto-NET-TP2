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

        public static ComisionExtended getComisionExtended(comisione com)
        {
            return new ComisionExtended(com);
        }

        public static List<ComisionExtended> getComisionesExtended(List<comisione> comisiones)
        {
            List<ComisionExtended> list = new List<ComisionExtended>();
            foreach (comisione c in comisiones)
            {
                list.Add(getComisionExtended(c));
            }
            return list;
        }

        public class ComisionExtended 
        {
            private int id_comision;
            private string desc_comision;
            private int anio_especialidad;
            private string plan;
            #region propiedades
            public string Plan
            {
                get { return plan; }
                set { plan = value; }
            }

            public int Anio_especialidad
            {
                get { return anio_especialidad; }
                set { anio_especialidad = value; }
            }

            public string Desc_comision
            {
                get { return desc_comision; }
                set { desc_comision = value; }
            }

            public int Id_comision
            {
                get { return id_comision; }
                set { id_comision = value; }
            }
            #endregion
            public ComisionExtended(comisione com) 
            {
                this.Id_comision = com.id_comision;
                this.Desc_comision = com.desc_comision;
                this.Anio_especialidad = com.anio_especialidad;
                PlanLogic logic = new PlanLogic();
                this.Plan = logic.GetOne(com.id_plan).desc_plan;
            }
        }//end sub class
    }//end class
}
