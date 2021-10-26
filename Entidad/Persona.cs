using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Persona
    {
        [Key]
        public int Identificacion { get; set; }
        public string tipoIdentificacion { get; set; }
   
        

    }
}
