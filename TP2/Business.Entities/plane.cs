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
    
    public partial class plane
    {
        public plane()
        {
            this.comisiones = new HashSet<comisione>();
            this.materias = new HashSet<materia>();
            this.personas = new HashSet<persona>();
        }
    
        public int id_plan { get; set; }
        public string desc_plan { get; set; }
        public int id_especialidad { get; set; }
    
        public virtual ICollection<comisione> comisiones { get; set; }
        public virtual especialidade especialidade { get; set; }
        public virtual ICollection<materia> materias { get; set; }
        public virtual ICollection<persona> personas { get; set; }
    }
}