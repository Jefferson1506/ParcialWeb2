using System.Data.Common;
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


            try
            {
                var personaBuscar = _context.Personas.Find(infraccion.Persona.Identificacion);
                var infraccionBuscar = _context.Infracciones.Find(infraccion.IdInfraccion);

                if (infraccionBuscar != null)
                    return new GuardarInfraccionResponse("LA INFRACCION YA EXISTE");

                if (infraccion.CodigoInf == "D02" || infraccion.CodigoInf == "B01" || infraccion.CodigoInf == "C38")
                {

                    if (personaBuscar == null) return new GuardarInfraccionResponse("PERSONA NO EXISTE ");

                    infraccion.Persona = personaBuscar;
                    _context.Infracciones.Add(infraccion);
                    _context.SaveChanges();

                    return new GuardarInfraccionResponse(infraccion);

                }
                else
                {

                    return new GuardarInfraccionResponse("EL CODIGO DE LA FACTURA NO ES VALIDAD");
                }


            }
            catch (Exception e)
            {
                return new GuardarInfraccionResponse($"ERROR EN GUARDA INFRACCION : {e.Message}");

            }

        }



        public List<Infraccion> ConsultarTodos()
        {
            List<Infraccion> infracciones = _context.Infracciones.ToList();

            return infracciones;
        }


        public Persona BuscarxIdentificacion(int identificacion)
        {
            Persona persona = _context.Personas.Find(identificacion);
            return persona;
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