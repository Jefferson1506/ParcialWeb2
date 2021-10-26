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
       






  public string Eliminar(int identificacion)
        {
            try
            {
                var persona = _context.Personas.Find(identificacion);
                if (persona != null)
                {
                    _context.Personas.Remove(persona);
                    _context.SaveChanges();
                    return (
                    $"El registro {persona.Nombre} se ha eliminado satisfactoriamente."
                    );
                }
                else
                {
                    return (
                    $"Lo sentimos, {identificacion} no se encuentra registrada."
                    );
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }

        public Persona BuscarxIdentificacion(int identificacion)
        {
            Persona persona = _context.Personas.Find(identificacion);
            return persona;
        }

        public GuardarPersonaResponse Modificar(Persona personaNew){
                try{
                    var personaOld = _context.Personas.Find(personaNew.Identificacion);
                    if(personaOld !=null){
                        personaOld.Identificacion = personaNew.Identificacion;
                        personaOld.Nombre = personaNew.Nombre;
                        personaOld.Edad = personaNew.Edad;
                        _context.Personas.Update(personaOld);
                        _context.SaveChanges();
                        return new GuardarPersonaResponse(personaOld);
                    }

                    return new GuardarPersonaResponse($"No existe {personaNew.Nombre}");


                }catch (Exception e){
                    return new GuardarPersonaResponse(e.Message);
                }

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