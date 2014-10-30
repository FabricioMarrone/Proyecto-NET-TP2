using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.DataBase;
using Business.Entities;
using System.Collections;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter _cursoAdapter;

        public CursoLogic() 
        {
            this._cursoAdapter = new CursoAdapter();
        }

        public curso GetOne(int id)
        {
            return this._cursoAdapter.GetOne(id);
        }

        public List<curso> GetAll()
        {
            return this._cursoAdapter.GetAll();
        }

        public IList GetCursosParaInscripcion(int idMateria)
        {
            return this._cursoAdapter.GetCursosParaInscripcion(idMateria);
        }

        public void Save(curso cur, string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this._cursoAdapter.Insert(cur);
                    break;
                case "Baja":
                    this._cursoAdapter.Delete(cur.id_curso);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this._cursoAdapter.Update(cur);
                    break;
            }
        }

        public void Delete(int id)
        {
            this._cursoAdapter.Delete(id);
        }

        public static CursoExtended getCursoExtended(curso cur) 
        {
            return new CursoExtended(cur);
        }

        public static List<CursoExtended> getCursosExtended(List<curso> cursos)
        {
            List<CursoExtended> list = new List<CursoExtended>();
            foreach (curso cur in cursos) {
                list.Add(getCursoExtended(cur));
            }
            return list;
        }

        public class CursoExtended 
        {
            private int id_curso;
            private string desc;

            public string DESC
            {
                get { return desc; }
                set { desc = value; }
            }
            public int ID_CURSO
            {
                get { return id_curso; }
                set { id_curso = value; }
            }

            public CursoExtended(curso cur)
            {

                this.ID_CURSO = cur.id_curso;
                MateriaLogic logic = new MateriaLogic();
                materia mat = logic.GetOne(cur.id_materia);
                ComisionLogic comLogic = new ComisionLogic();
                comisione com = comLogic.GetOne(cur.id_comision);
                this.DESC = mat.desc_materia + " (Com:" + com.desc_comision + ")";

            }
        }//end sub class

    }//end class
}
