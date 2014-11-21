﻿using System;
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
        }

        public ExceptionUsuarioInhabilitado(string mensaje) : base()
        {
            this.mensaje = mensaje;
        }
    }
}
