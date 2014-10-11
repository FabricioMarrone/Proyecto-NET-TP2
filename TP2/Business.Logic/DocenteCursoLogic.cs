using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.DataBase;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private DocenteCursoAdapter _docenteCursoAdapter;

        public DocenteCursoLogic() 
        {
            _docenteCursoAdapter = new DocenteCursoAdapter();
        }

        public docentes_cursos GetOne(int id)
        {
            return this._docenteCursoAdapter.GetOne(id);
        }

        public List<docentes_cursos> getAll() 
        {
            return this._docenteCursoAdapter.GetAll();
        }

        public void save(docentes_cursos doc_cur, string modo) 
        {
            switch (modo)
            {
                case "Alta":
                    this._docenteCursoAdapter.Insert(doc_cur);
                    break;
                case "Baja":
                    this._docenteCursoAdapter.Delete(doc_cur.id_dictado);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this._docenteCursoAdapter.Update(doc_cur);
                    break;
            }
        }
    }//end class
}
