using Entidad;
using System;




     public class InfraccionInputModel
    {
        public int IdInfraccion { get; set; }
        public string CodigoInf { get; set; }

        public String DescripcionInf { get; set; }

        public int ValorInf { get; set; }
    }

    public class InfraccionViewModel : InfraccionInputModel
    {
       
      public InfraccionViewModel(Infraccion infraccion){
           IdInfraccion  = infraccion.IdInfraccion;
            CodigoInf = infraccion.CodigoInf;
            DescripcionInf=infraccion.DescripcionInf;
            ValorInf=infraccion.ValorInf;
            
      }
      
    }
