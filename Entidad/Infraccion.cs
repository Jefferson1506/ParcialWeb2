using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Infraccion
    {
        [Key]
        public int IdInfraccion { get; set; }
        public string CodigoInf { get; set; }

        public String DescripcionInf { get; set; }

        public int ValorInf { get; set; }

        public Persona Persona { get; set; }
    }
}