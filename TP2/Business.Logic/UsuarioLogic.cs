using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.DataBase;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter _usuarioData;

        public UsuarioLogic()
        {
            this._usuarioData = new UsuarioAdapter();
        }

        public UsuarioAdapter UsuarioData
        {
            get { return _usuarioData; }
            set { _usuarioData = value; }
        }

        public usuario GetOne(int id)
        {
            try
            {
                return this._usuarioData.GetOne(id);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public usuario getByName(string name) {
            return this._usuarioData.getByName(name);
        }

       

        public List<usuario> GetAll()
        {
            try
            {
                return this._usuarioData.GetAll();
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        public void Delete(int id) {
            this.UsuarioData.Delete(id);
        }

        public void Save(usuario usr, string modo)
        {
            try
            {
                switch (modo)
                {
                    case "Alta":
                        this.UsuarioData.Insert(usr);
                        break;
                    case "Baja":
                        this.UsuarioData.Delete(usr.id_usuario);
                        break;
                    case "Modificacion":
                        //revisar No se necesita pasar el USR.
                        this.UsuarioData.Update(usr);
                        break;
                }
                //this._usuarioData.Save(usu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
