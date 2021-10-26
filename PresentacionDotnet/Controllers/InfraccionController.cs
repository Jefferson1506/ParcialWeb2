using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidad;
using Logica;
using Microsoft.Extensions.Configuration;
using Datos;

namespace PresentacionDotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfraccionController : ControllerBase
    {
        private readonly InfraccionService _infraccionService;

    public IConfiguration Configuration { get; }

     public InfraccionController(ParcialWebContext context)
    {
       _infraccionService= new InfraccionService(context);
    }

      private Infraccion MapearInfraccion(InfraccionInputModel infraccionInput)
    {
        var infraccion = new Infraccion
        {
            IdInfraccion = infraccionInput.IdInfraccion,
            CodigoInf = infraccionInput.CodigoInf,
            DescripcionInf=infraccionInput.DescripcionInf,
            ValorInf=infraccionInput.ValorInf,
            FechaInfraccion=infraccionInput.FechaInfraccion,
            Persona = infraccionInput.Persona
        };
        return infraccion;
    }


     // POST: registrar las multas
    [HttpPost]
    public ActionResult<PersonaViewModel> Post(InfraccionInputModel infraccionInput)
    {
        Infraccion infraccion = MapearInfraccion(infraccionInput);

        var response = _infraccionService.GuardarInfraccion(infraccion);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Infraccion);
    }

    //Get : para mostar la lista de codigos que tengo
        [HttpGet]
    public IEnumerable<InfraccionViewModel> Gets()
    {
        var infracciones = _infraccionService.ConsultarTodos().Select(i => new InfraccionViewModel(i));
        return infracciones;
    }


    }

   
}