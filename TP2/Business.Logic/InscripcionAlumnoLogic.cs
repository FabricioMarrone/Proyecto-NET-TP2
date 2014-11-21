using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.DataBase;
using Util;

namespace Business.Logic
{
    public class InscripcionAlumnoLogic : BusinessLogic
    {
        private InscripcionAlumnoAdapter _inscripcionAlumnoAdapter;

        public InscripcionAlumnoLogic() 
        {
            this._inscripcionAlumnoAdapter = new InscripcionAlumnoAdapter();
        }

        public alumnos_inscripciones GetOne(int id)
        {
            return this._inscripcionAlumnoAdapter.GetOne(id);
        }

        public List<alumnos_inscripciones> GetAll()
        {
            return this._inscripcionAlumnoAdapter.GetAll();
        }

        public void Save(alumnos_inscripciones ai, string modo)
        {
            switch (modo)
            {
                case "Alta":
                    this._inscripcionAlumnoAdapter.Insert(ai);
                    break;
                case "Baja":
                    this._inscripcionAlumnoAdapter.Delete(ai.id_inscripcion);
                    break;
                case "Modificacion":
                    //revisar No se necesita pasar el USR.
                    this._inscripcionAlumnoAdapter.Update(ai);
                    break;
            }
        }

        public void Save(List<alumnos_inscripciones> alumsIncriptos)
        {
            foreach (alumnos_inscripciones ai in alumsIncriptos)
            {
                this.Save(ai, "Modificacion");
            }
        }

        public void Delete(int id)
        {
            this._inscripcionAlumnoAdapter.Delete(id);
        }

        public IList getInscripcionesDelAlumno(persona alu) 
        {
            return this._inscripcionAlumnoAdapter.getInscripcionesDelAlumno(alu);
        }

        public List<alumnos_inscripciones> GetAlumnosDeCurso(int IDCurso)
        {
            List<alumnos_inscripciones> alumnosInsc = this._inscripcionAlumnoAdapter.GetAlumnosDeCurso(IDCurso);
            if (alumnosInsc.Count == 0)
            {
                throw new ListaEmptyException("No existen alumnos inscriptos en este curso.");
            }
            return alumnosInsc;
        }

        public static InscripcionAlumnoExtendent getAlumnoInscripcionExtended(alumnos_inscripciones ai)
        {
            return new InscripcionAlumnoExtendent(ai);
        }

        public static List<InscripcionAlumnoExtendent> getAlumnosInscripcionesExtended(List<alumnos_inscripciones> ais)
        {
            List<InscripcionAlumnoExtendent> list = new List<InscripcionAlumnoExtendent>();
            foreach (alumnos_inscripciones ai in ais)
            {
                list.Add(getAlumnoInscripcionExtended(ai));
            }
            return list;
        }

        public class InscripcionAlumnoExtendent {
            private int id_inscripcion;

            public int Id_inscripcion
            {
                get { return id_inscripcion; }
                set { id_inscripcion = value; }
            }

            private string alumno;

            public string Alumno
            {
                get { return alumno; }
                set { alumno = value; }
            }

            private int? legajo;

            public int? Legajo
            {
                get { return legajo; }
                set { legajo = value; }
            }

            private string materia;

            public string Materia
            {
                get { return materia; }
                set { materia = value; }
            }

            private int anioCalendario;

            public int AnioCalendario
            {
                get { return anioCalendario; }
                set { anioCalendario = value; }
            }


            private string condicion;

            public string Condicion
            {
                get { return condicion; }
                set { condicion = value; }
            }

            private int? nota;

            public int? Nota
            {
                get { return nota; }
                set { nota = value; }
            }

            public InscripcionAlumnoExtendent(alumnos_inscripciones ai) 
            {
                this.Id_inscripcion = ai.id_inscripcion;
                PersonaLogic personaLogic = new PersonaLogic();
                persona p = personaLogic.GetOne(ai.id_alumno);
                this.Alumno = p.apellido + ", "+ p.nombre;
                this.Legajo = p.legajo;

                //Para obtener el nombre de la materia.
                CursoLogic cursoLogic = new CursoLogic();
                MateriaLogic materiaLogic = new MateriaLogic();
                curso oCurso = cursoLogic.GetOne(ai.id_curso);
                this.Materia = (materiaLogic.GetOne(oCurso.id_materia)).desc_materia;

                this.anioCalendario = oCurso.anio_calendario;

                this.Condicion = ai.condicion;
                this.nota = ai.nota;
            }

            public InscripcionAlumnoExtendent() { 
            }
        
        }

    }//end class
}
