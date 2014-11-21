using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class ListaEmptyException : Exception
    {
        private string mensaje;

        public string Mensaje
        {
            get { return mensaje; }
        }

        public ListaEmptyException(string mensaje)
        {
            this.mensaje = mensaje;
        }
    }
}
