using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidad;
using Logica;
using Microsoft.Extensions.Configuration;
using Datos;

[Route("api/[controller]")]
[ApiController]
public class PersonaController : ControllerBase
{
    private readonly PersonaService _personaService;

    public IConfiguration Configuration { get; }


    public PersonaController(ParcialWebContext context)
    {
        _personaService = new PersonaService(context);
    }

    // GET: api/Persona


    [HttpGet]
    public IEnumerable<PersonaViewModel> Gets()
    {
        var personas = _personaService.ConsultarTodos().Select(p => new PersonaViewModel(p));
        return personas;
    }


    // POST: api/Persona
    [HttpPost]
    public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
    {
        Persona persona = MapearPersona(personaInput);
        var response = _personaService.Guardar(persona);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Persona);
    }

    // GET: api/Persona/5
    [HttpGet("{identificacion}")]
    public ActionResult<PersonaViewModel> Get(int identificacion)
    {
        var persona = _personaService.BuscarxIdentificacion(identificacion);
        if (persona == null) return NotFound();
        var personaViewModel = new PersonaViewModel(persona);
        return personaViewModel;
    }

//modificar
    [HttpPut]

    public ActionResult<string> Put(PersonaInputModel personaInput){

            Persona persona = MapearPersona(personaInput);
            var respuesta = _personaService.Modificar(persona);

            if(respuesta.Error){
                return BadRequest(respuesta.Mensaje);
            }

        return Ok(respuesta.Persona);
    }

    // DELETE: api/Persona/5
    [HttpDelete("{identificacion}")]
    public ActionResult<string> Delete(int identificacion)
    {
        string mensaje = _personaService.Eliminar(identificacion);
        return Ok(mensaje);
    }

    private Persona MapearPersona(PersonaInputModel personaInput)
    {
        var persona = new Persona
        {
            Identificacion = personaInput.Identificacion,
            Nombre = personaInput.Nombre,
            Edad = personaInput.Edad,
        };
        return persona;
    }

}


