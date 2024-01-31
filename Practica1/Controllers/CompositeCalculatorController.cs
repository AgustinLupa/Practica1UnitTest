using Microsoft.AspNetCore.Mvc;
using Practica1.Database;
using Practica1.Models;
using Practica1.Models.Interface;
using Practica1.Repository;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica1.Controllers
{
    [Route("api")]
    [ApiController]
    public class CompositeCalculatorController : ControllerBase
    {
        ICompositeCalculatorServices compositeCalculatorService;

        public CompositeCalculatorController(ICompositeCalculatorServices services)
        {
            compositeCalculatorService = services;
        }

        // POST 
        [Route("Calculadora")]
        [HttpPost]
        public IActionResult Post([FromBody] CompositeCalculator compositeCalculator)
        {
            try
            {
                var json =  compositeCalculatorService.Calculate(compositeCalculator) ;
                return Ok(json);
            }
            catch (ArgumentException e)
            {
                return BadRequest($"Error en la solicitud: {e.Message}");
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }        
    }
}
