using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class MateriaAdapter : Data.DataBase.Adapter
    {
        public Business.Entities.materia GetOne(int id)
        {
            using(AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryMateria = (from mat in academiaContext.materias
                                    where mat.id_materia == id
                                    select mat).First();
                return queryMateria;
            }
        }

        public List<materia> GetAll()
        {
            using(AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryMaterias = (from mat in academiaContext.materias
                                     select mat).ToList();
                return queryMaterias;
            }
        }

        public void Insert(materia oMateria) { 
            using(AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.materias.Add(oMateria);
                academiaContext.SaveChanges();
            }
        }

        public void Update(materia oMateria) { 
            using(AcademiaEntities academiaContext = new AcademiaEntities())
            {
                materia queryMateria = (from mat in academiaContext.materias
                                        where mat.id_materia == oMateria.id_materia
                                        select mat).First();
                queryMateria.desc_materia = oMateria.desc_materia;
                queryMateria.hs_semanales = oMateria.hs_semanales;
                queryMateria.hs_totales = oMateria.hs_totales;
                queryMateria.id_plan = oMateria.id_plan;

                academiaContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using(AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryMateria = (from mat in academiaContext.materias
                                    where mat.id_materia == id
                                   select mat).First();

                academiaContext.materias.Remove(queryMateria);
                academiaContext.SaveChanges();
            }            
        }

        public List<materia> GetMateriasParaInscripcion(persona oPersona)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                // Sub consulta: Devuelve los id_materia de las Materias para las cuales el alumno
                // ya esta Inscripto o Regular.
                var subQuery = from insc in academiaContext.alumnos_inscripciones
                               where (insc.id_alumno == oPersona.id_persona) &&
                                     (insc.condicion == "Regular" || insc.condicion == "Inscripto")
                               select insc.curso.id_materia;

                /* Consulta que devuelve las materias de acuerdo a la especialidad y
                 * plan de la persona(Alumno). Asi nos evitamos que puedan inscribirse
                 * a materias de otras especialidades que no son de la suya.
                 * Tampoco se incluiran las materias a las cuales el alumno ya esta
                 * Inscrito o Regular.
                */
                var queryMaterias = (from mat in academiaContext.materias
                                     where (mat.id_plan == oPersona.id_plan) &&
                                     !(subQuery.Contains(mat.id_materia))
                                     select mat).ToList();
                return queryMaterias;
            }
        }
    }
}
