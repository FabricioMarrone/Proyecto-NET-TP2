using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Business.Entities;

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

            //Console.WriteLine((int)persona.tipo.Alumno);
            //Console.WriteLine((int)persona.tipo.Admin);
            //Console.WriteLine((int)persona.tipo.Profesor);
            //Console.WriteLine(DateTime.Today.ToShortDateString());

            //Application.Run(new formMain());
            //Application.Run(new ListarUsuarios());
            //Application.Run(new ListarEspecialidades());
            //Application.Run(new ListarComisiones());
            //Application.Run(new ListarPlanes());
            //Application.Run(new ListarMaterias());
            //Application.Run(new ListarCursos());
            //Application.Run(new ListarPersonas());
            //Application.Run(new ProfesorCursoABM(ApplicationForm.ModoForm.Alta));
            //Application.Run(new ListarDocentesCursos());
            Application.Run(new ListarInscripcionesAlumnos());


        }
    }
}
