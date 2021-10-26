using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class InfraccionService
    {
        
         private readonly ParcialWebContext _context;
        public InfraccionService(ParcialWebContext context)
        {
                    _context = context;
        }

          public GuardarInfraccionResponse GuardarInfraccion(Infraccion infraccion)
        {
           
           try{
               var infraccionesGuardar = _context.Infracciones.Find(infraccion.CodigoInf);
                
               if(infraccionesGuardar !=null)return new GuardarInfraccionResponse("ERROR LA INFRACCION YA ESTA REGISTRADA");
            
                _context.Infracciones.Add(infraccion);
                _context.SaveChanges();

                return new GuardarInfraccionResponse(infraccion);

           }catch(Exception e) {
               return new GuardarInfraccionResponse($"ERROR EN GUARDA INFRACCION : {e.Message}");

           }

        }

          public List<Infraccion> ConsultarTodos()
        {
            List<Infraccion> infracciones = _context.Infracciones.ToList();
       
            return infracciones;
        }




         public class GuardarInfraccionResponse 
    {
        public GuardarInfraccionResponse(Infraccion infraccion)
        {
            Error = false;
            Infraccion = infraccion;
        }
        public GuardarInfraccionResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Infraccion Infraccion { get; set; }
    }

    }
}