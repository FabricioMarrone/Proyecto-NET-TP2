using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace Data.DataBase
{
    public class UsuarioAdapter : Adapter
    {
        public List<usuario> GetAll()
        {
            using(AcademiaEntities academiaContext = new AcademiaEntities()){
                var querySQL = (from usr in academiaContext.usuarios
                                select usr).ToList();

                var queryMetodo = (academiaContext.usuarios).ToList();
                return querySQL;
            }
        }

        public usuario GetOne(int ID)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Linq tipo consulta SQL
                var querySQL = (from usr in academiaContext.usuarios
                                where usr.id_usuario == ID
                                select usr).Single();

                var queryMetodo = (academiaContext.usuarios
                                   .Where(usr => usr.id_usuario == ID)
                                   ).First();

                return querySQL;
            }

        }

        public usuario getByName(string name) {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                return academiaContext.usuarios.Where(u => u.nombre_usuario == name).FirstOrDefault();
            }
        }

        public void Insert(usuario usr)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.usuarios.Add(usr);
                academiaContext.SaveChanges();
            }
        }

        public void Update(Business.Entities.usuario usr)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryGetOne = (from usu in academiaContext.usuarios
                                   where usu.id_usuario == usr.id_usuario
                                   select usu).First();
                usuario u = queryGetOne;

                u.nombre = usr.nombre;
                u.apellido = usr.apellido;
                u.nombre_usuario = usr.nombre_usuario;
                u.email = usr.email;
                u.clave = usr.clave;
                u.habilitado = usr.habilitado;

                academiaContext.SaveChanges();
            }

        }

        public void Delete(int ID)
        {
            try
            {
                using (AcademiaEntities academiaContext = new AcademiaEntities())
                {
                    var query = (from usr in academiaContext.usuarios
                                where usr.id_usuario == ID
                                select usr).First();
                    academiaContext.usuarios.Remove(query);
                    academiaContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(usuario usr) {
            try
            {
                using (AcademiaEntities academiaContext = new AcademiaEntities())
                {
                    academiaContext.usuarios.Remove(usr);
                    academiaContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<usuario> BuscarPorApellido(string apellido)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                List<usuario> queryUsuarios = (from u in academiaContext.usuarios
                                               where u.apellido.ToLower() == apellido.ToLower()
                                               select u).ToList();
                return queryUsuarios;
            }
        }
    }
}
