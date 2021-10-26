using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Persona
    {
        [Key]
        public int Identificacion { get; set; }
        
        public string Nombre { get; set; }
        
        public int Edad { get; set; }
    }
}
