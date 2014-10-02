using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new formMain());
            //Application.Run(new UsuarioDesktop());
            Application.Run(new ListarUsuarios());
            //Application.Run(new ListarEspecialidades());
           
        }
    }
}
