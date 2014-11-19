using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    class ExceptionUsuarioInhabilitado : Exception
    {
        private string mensaje;

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public ExceptionUsuarioInhabilitado(string mensaje) 
        {
            this.mensaje = mensaje;
        }
    }
}
