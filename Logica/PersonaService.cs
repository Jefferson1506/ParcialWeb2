using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class PersonaService
    {
        private readonly ParcialWebContext _context;
        public PersonaService(ParcialWebContext context)
        {
                    _context = context;
        }

        
        public GuardarPersonaResponse Guardar(Persona persona)
        {
           
           try{
               var personaGuardar = _context.Personas.Find(persona.Identificacion);

               if(personaGuardar !=null)return new GuardarPersonaResponse("LA PERSONA YA EXISTE");
            
                _context.Personas.Add(persona);
                _context.SaveChanges();

                return new GuardarPersonaResponse(persona);


           }catch(Exception e) {
               return new GuardarPersonaResponse($"ERRO EN LA GUARDA PERSONA : {e.Message}");

           }



        }
        public List<Persona> ConsultarTodos()
        {
            List<Persona> personas = _context.Personas.ToList();
       
            return personas;
        }
       
    public class GuardarPersonaResponse 
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
}
}