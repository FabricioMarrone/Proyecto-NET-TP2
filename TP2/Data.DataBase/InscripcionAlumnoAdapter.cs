﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.DataBase
{
    public class InscripcionAlumnoAdapter : Adapter
    {

    
        public alumnos_inscripciones GetOne(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var querySQL = (from ai in academiaContext.alumnos_inscripciones
                                where ai.id_inscripcion == id
                                select ai).Single();

                return querySQL;
            }
        }

        public List<alumnos_inscripciones> GetAll()
        {
            using (AcademiaEntities context = new AcademiaEntities())
            {
                var querySQL = (from ai in context.alumnos_inscripciones
                                select ai).ToList();
                return querySQL;
            }
        }

        public void Insert(alumnos_inscripciones ai)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.alumnos_inscripciones.Add(ai);
                academiaContext.SaveChanges();
            }
        }

        public void Update(alumnos_inscripciones alu_i)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var queryGetOne = (from ai in academiaContext.alumnos_inscripciones
                                   where ai.id_inscripcion == alu_i.id_inscripcion
                                   select ai).First();
                alumnos_inscripciones ali = queryGetOne;

                ali.id_alumno = alu_i.id_alumno;
                ali.id_curso = alu_i.id_curso;
                ali.condicion = alu_i.condicion;
                ali.nota = alu_i.nota;

                academiaContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                var query = (from ai in academiaContext.alumnos_inscripciones
                             where ai.id_inscripcion == id
                             select ai).First();
                academiaContext.alumnos_inscripciones.Remove(query);
                academiaContext.SaveChanges();
            }
        }

        public void Delete(alumnos_inscripciones alumnoinscrip)
        {
            using (AcademiaEntities academiaContext = new AcademiaEntities())
            {
                academiaContext.alumnos_inscripciones.Remove(alumnoinscrip);
                academiaContext.SaveChanges();
            }
        }
    }//end class
}