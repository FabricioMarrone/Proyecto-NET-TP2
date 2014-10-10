using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Util
{
    public class Validador
    {

        public static bool ValidarClave(string clave)
        {
            return clave.Length >= 8 && clave.Length <= 15;
        }

        public static bool ValidarEMail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$");
        }

        public static bool ValidarCadenaSoloTexto(string cadena) 
        {
            return Regex.IsMatch(cadena,@"");
        }

    }
}
