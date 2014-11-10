using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Util
{
    public class Validador
    {
        private static string expreCadenaNumerica = @"^[0-9]{2}$";

        public static string ExpreCadenaNumerica
        {
            get { return Validador.expreCadenaNumerica; }
        }

        private static string expreAnioEspecialidad = @"^([1-5])$";

        public static string ExpreAnioEspecialidad
        {
            get { return Validador.expreAnioEspecialidad; }
            set { Validador.expreAnioEspecialidad = value; }
        }

        private static string expreEnteroPositivo = @"^([1-9]|[1-9][0-9]|[1-9][0-9][0-9])$";

        public static string ExpreEnteroPositivo
        {
            get { return Validador.expreEnteroPositivo; }
            set { Validador.expreEnteroPositivo = value; }
        }

        private static string expreCadenaTextoYNumeros = @"^(([a-zA-Z\d])+\s?)+$";

        public static string ExpreCadenaTextoYNumeros
        {
            get { return Validador.expreCadenaTextoYNumeros; }
            set { Validador.expreCadenaTextoYNumeros = value; }
        }

        private static string expreAnio = @"^20([1-9][\d])$";

        public static string ExpreAnio
        {
            get { return Validador.expreAnio; }
            set { Validador.expreAnio = value; }
        }

        private static string expreTelefono = @"^[0-9]{7,11}$";

        public static string ExpreTelefono
        {
            get { return Validador.expreTelefono; }
            set { Validador.expreTelefono = value; }
        }

        private static string expreLegajo = @"^[0-9]{5}$";

        public static string ExpreLegajo
        {
            get { return Validador.expreLegajo; }
        }

        private static string expreCadenaSoloTexto = @"^(([a-zA-Z])+\s?)+$";

        public static string ExpreCadenaSoloTexto
        {
            get { return Validador.expreCadenaSoloTexto; }
        }

        private static string expreNombreUsuario = @"^([a-zA-Z\d]+)$";

        public static string ExpreNombreUsuario
        {
            get { return Validador.expreNombreUsuario; }
        }

        private static string expreDireccion = @"^(([a-zA-Z])+\s?)+([\d]+){1}(\s?(P|p)\d{1,3}\s?(D|d)\d{1,3})?$";

        public static string ExpreDireccion
        {
            get { return Validador.expreDireccion; }
        }

        private static string expreClave = @"^([a-zA-Z0-9]{8,15})$";

        public static string ExpreClave
        {
            get { return Validador.expreClave; }
        }

        private static string expreEMail = @"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$";

        public static string ExpreEMail
        {
            get { return Validador.expreEMail; }
        }

        private static string expreFecha = @"^(0?[1-9]|[12][0-9]|3[01])/(0?[1-9]|1[012])/((19|20)\d\d)$";

        public static string ExpreFecha
        {
            get { return Validador.expreFecha; }
        }

        public static bool ValidarCadenaNumerica(string numero, int longMin, int longMax)
        {
            // Aplicable Para Telefonos, Legajos, etc.
            string expresion = "^[0-9]";

            if (longMax == 0)
            {
                expresion += ("{" + longMin + "}$");
            }
            else
            {
                expresion += "{" + longMin + "," + longMax + "}$";
            }

            return Regex.IsMatch(numero, expresion);
        }

        public static bool ValidarAnioEspecialidad(string numero)
        {
            return Regex.IsMatch(numero, @"^([1-5])$");
        }

        public static bool ValidarEnteroPositivo(string numero)
        {
            // Aplicable para Cantidades. Como por ej: Cupos.
            //return Regex.IsMatch(numero, @"^([" + limiteMin + "-" + limiteMax + "])$");
            return Regex.IsMatch(numero, @"^([1-9]|[1-9][0-9]|[1-9][0-9][0-9])$");
        }

        public static bool ValidarCadenaTextoYNumeros(string cadena)
        {
            return Regex.IsMatch(cadena, @"^(([a-zA-Z\d])+\s?)+$");
        }

        public static bool ValidarAnio(string numero) 
        {
            return Regex.IsMatch(numero, @"^20([1-9][\d])$");
        }

        public static bool ValidarTelefono(string numero)
        {
            // minimo = 5 para telefonos de rosario sin codigo de area.
            // maximo = 9 para telefonos con codigo de area. 
            return ValidarCadenaNumerica(numero, 7, 11);
        }

        public static bool ValidarLegajo(string legajo)
        {
            // Preguntar
            // {XX}-{XXXXX} con identificador especialidad? 
            // {XXXXX} sin identificador especialidad?
            return ValidarCadenaNumerica(legajo, 5, 0);
        }

        public static bool ValidarCadenaSoloTexto(string cadena)
        {
            return Regex.IsMatch(cadena, @"^(([a-zA-Z])+\s?)+$");
        }

        public static bool ValidarNombreUsuario(string cadena)
        {
            return Regex.IsMatch(cadena, @"^([a-zA-Z\d]+)$");
        }

        public static bool ValidarDireccion(string direccion)
        {
            return Regex.IsMatch(direccion, @"^(([a-zA-Z])+\s?)+([\d]+){1}(\s?(P|p)\d{1,3}\s?(D|d)\d{1,3})?$");
        }

        public static bool ValidarClave(string clave, string confirmacion)
        {
            return ( (Regex.IsMatch(clave, @"^([a-zA-Z0-9]{8,15})$")) && (clave.Equals(confirmacion)) );
        }

        public static bool ValidarEMail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$");
        }

        public static bool ValidarFecha(string fecha)
        {
            return Regex.IsMatch(fecha, @"^(0?[1-9]|[12][0-9]|3[01])/(0?[1-9]|1[012])/((19|20)\d\d)$");   
        }

        public static bool ValidarCampoNoVacio(string campo)
        {
            return campo.Trim() != "";
        }

    }
}
