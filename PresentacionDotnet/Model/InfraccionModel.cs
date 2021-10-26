using Entidad;
using System;
using System.ComponentModel.DataAnnotations;



     public class InfraccionInputModel
    {
      [Key]
        public int IdInfraccion { get; set; }
        public string CodigoInf { get; set; }

        public String DescripcionInf { get; set; }

        public int ValorInf { get; set; }

        public DateTime FechaInfraccion { get; set; }

        public Persona Persona{get;set;}
    }

    public class InfraccionViewModel : InfraccionInputModel
    {
       
      public InfraccionViewModel(Infraccion infraccion){
           IdInfraccion  = infraccion.IdInfraccion;
            CodigoInf = infraccion.CodigoInf;
            DescripcionInf=infraccion.DescripcionInf;
            ValorInf=infraccion.ValorInf;
            FechaInfraccion = infraccion.FechaInfraccion;
            Persona = infraccion.Persona;
            
      }
      
    }
