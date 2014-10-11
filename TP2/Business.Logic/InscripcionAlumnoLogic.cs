using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.DataBase;

namespace Business.Logic
{
    public class InscripcionAlumnoLogic : BusinessLogic
    {
        private InscripcionAlumnoAdapter _inscripcionAlumnoAdapter;

        public InscripcionAlumnoLogic() 
        {
            this._inscripcionAlumnoAdapter = new InscripcionAlumnoAdapter();
        }

        public alumnos_inscripciones GetOne(int id)
        {
            return this._inscripcionAlumnoAdapter.GetOne(id);
        }

        public List<alumnos_inscripciones> GetAll()
        {
            return this._inscripcionAlumnoAdapter.GetAll();
        }

        public void Save(alumnos_inscripciones ai, string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this._inscripcionAlumnoAdapter.Insert(ai);
                    break;
                case "Baja":
                    this._inscripcionAlumnoAdapter.Delete(ai.id_inscripcion);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this._inscripcionAlumnoAdapter.Update(ai);
                    break;
            }
        }

        public void Delete(int id)
        {
            this._inscripcionAlumnoAdapter.Delete(id);
        }
    }//end class
}
