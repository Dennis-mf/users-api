using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace users_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {

        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Conexion a base de datos terminada");

            Thread.Sleep(1000);
            Console.WriteLine("Envio de Email terminado");

            Console.WriteLine("Todas las operaciones finalizadas");

            stopWatch.Stop();

           return Ok(stopWatch.Elapsed);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            var task1 = new Task<int>(() => {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a base de datos terminada");
                return 10;
            });

            task1.Start();

            Console.WriteLine("Otro proceso");

            var result = await task1;

            Console.WriteLine("Proceso terminado");

            return Ok(result);
        }
    }
}
