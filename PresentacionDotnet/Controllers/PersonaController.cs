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

    private Persona MapearPersona(PersonaInputModel personaInput)
    {
        var persona = new Persona
        {
            Identificacion = personaInput.Identificacion,
            tipoIdentificacion  = personaInput.tipoIdentificacion
        };
        return persona;
    }

}


