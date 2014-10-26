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
    }//end class
}
