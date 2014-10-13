using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.DataBase;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter _personaData;

        public PersonaLogic() 
        {
            this._personaData = new PersonaAdapter();
        }

        public persona GetOne(int? id)
        {
            if (id == null) return null;
            else return this._personaData.GetOne(id);
        }

        public List<persona> GetAll()
        {
            return this._personaData.GetAll();
        }

        public List<persona> GetAll(persona.tipo tipo)
        {
            return this._personaData.GetAll(tipo);
        }

        public void Save(persona persona, string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this._personaData.Insert(persona);
                    break;
                case "Baja":
                    this._personaData.Delete(persona.id_persona);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this._personaData.Update(persona);
                    break;
            }
        }

        public void Delete(int id)
        {
            this._personaData.Delete(id);
        }

    }
}
