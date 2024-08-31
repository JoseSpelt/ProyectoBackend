using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PrimerProyectoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync() 
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Thread.Sleep(1000);
            Console.WriteLine("Conexion a base de datos terminada");

            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail terminado");


            Console.WriteLine("Todo ha termino");
            stopwatch.Stop();
            return Ok(stopwatch.Elapsed);
        }
    }
}
