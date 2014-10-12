using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Util
{
    public class Validador
    {
        public static bool ValidarNumericoPositivo(string numero, int min, int max)
        {
            string expresion = "^[0-9]";
            if (max == 0)
            {
                expresion += ("{" + min + "}$");
            }
            else
            {
                expresion += "{" + min + "," + max + "}$";
            }

            return Regex.IsMatch(numero, expresion);
        }

        public static bool ValidarTelefono(string numero)
        {
            // minimo = 5 para telefonos de rosario sin codigo de area.
            // maximo = 9 para telefonos con codigo de area. 
            return ValidarNumericoPositivo(numero, 7, 11);
        }

        public static bool ValidarLegajo(string legajo)
        {
            // Preguntar
            // {XX}-{XXXXX} con identificador especialidad? 
            // {XXXXX} sin identificador especialidad?
            return ValidarNumericoPositivo(legajo, 5, 0);
        }

        public static bool ValidarCadenaSoloTexto(string cadena)
        {
            return Regex.IsMatch(cadena, @"^(([a-zA-Z])+\s?)+$");
        }

        public static bool ValidarDireccion(string direccion)
        {
            return Regex.IsMatch(direccion, @"^(([a-zA-Z])+\s?)+([\d]+){1}(\s?(P|p)\d{1,3}\s?(D|d)\d{1,3})?$");
        }

        public static bool ValidarClave(string clave, string confirmacion)
        {
            if (!(Regex.IsMatch(clave, @"^([a-zA-Z0-9]{8,15})$")) || !(clave.Equals(confirmacion)))
            {
                return false;
            }
            return true;
        }

        public static bool ValidarEMail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$");
        }

        public static bool ValidarFecha(string fecha)
        {
            return Regex.IsMatch(fecha, @"^([1-31]){1,2}\/([1-12]){1,2}\/([0-9]){4}$");
        }

        public static bool ValidarCamposNoVacios(string campo)
        {
            return campo.Trim() == "";
        }

    }
}