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
        private MateriaAdapter _materiaData;

        public MateriaAdapter MateriaData
        {
            get { return _materiaData; }
            set { _materiaData = value; }
        }

        public MateriaLogic()
        {
            this._materiaData = new MateriaAdapter();
        }

        public materia GetOne(int id)
        {
            return this.MateriaData.GetOne(id);
        }

        public List<materia> GetAll()
        {
            return this.MateriaData.GetAll();
        }

        public List<materia> GetMateriasParaInscripcion(persona oPersona)
        {
            return this.MateriaData.GetMateriasParaInscripcion(oPersona);
        }

        public List<materia> GetMateriasParaDictado(int idDocente, int idPlan) 
        {
            return this.MateriaData.GetMateriasParaDictado(idDocente,idPlan);
        }

        public void Save(materia oMateria,string modo)
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

        public static MateriaExtended getMateriaExtended(materia mat)
        {
            return new MateriaExtended(mat);
        }

        public static List<MateriaExtended> getMateriasExtended(List<materia> materias)
        {
            List<MateriaExtended> list = new List<MateriaExtended>();
            foreach (materia m in materias)
            {
                list.Add(getMateriaExtended(m));
            }
            return list;
        }

        public class MateriaExtended 
        {
            private int id_materia;
            private string desc_materia;
            private int hs_semanales;
            private int hs_totales;
            private string plan;
            #region propiedades
            public string Plan
            {
                get { return plan; }
                set { plan = value; }
            }

            public int Hs_totales
            {
                get { return hs_totales; }
                set { hs_totales = value; }
            }

            public int Hs_semanales
            {
                get { return hs_semanales; }
                set { hs_semanales = value; }
            }

            public string Desc_materia
            {
                get { return desc_materia; }
                set { desc_materia = value; }
            }
                
            public int Id_materia
            {
                get { return id_materia; }
                set { id_materia = value; }
            }
            #endregion
            public MateriaExtended(materia mat) 
            {
                this.Id_materia = mat.id_materia;
                this.Desc_materia = mat.desc_materia;
                this.Hs_semanales = mat.hs_semanales;
                this.Hs_totales = mat.hs_totales;
                PlanLogic logic = new PlanLogic();
                this.Plan = logic.GetOne(mat.id_plan).desc_plan;
            }
        }//end sub class
    }//end class
}
