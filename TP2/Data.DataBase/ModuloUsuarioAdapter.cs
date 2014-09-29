using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class ModuloUsuarioAdapter : Data.DataBase.Adapter
    {
        private static List<Business.Entities.modulos_usuarios> _ModulosUsuarios;

        public static List<Business.Entities.modulos_usuarios> ModulosUsuarios
        {
            get { return ModuloUsuarioAdapter._ModulosUsuarios; }
            set { ModuloUsuarioAdapter._ModulosUsuarios = value; }
        }

    }
}
