//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Business.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class materia
    {
        public materia()
        {
            this.cursos = new HashSet<curso>();
        }
    
        public int id_materia { get; set; }
        public string desc_materia { get; set; }
        public int hs_semanales { get; set; }
        public int hs_totales { get; set; }
        public int id_plan { get; set; }
    
        public virtual ICollection<curso> cursos { get; set; }
        public virtual plane plane { get; set; }
    }
}