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
            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var task1 = new Task<int>(() => {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a base de datos terminada");
                return 10;
            });

            var task2 = new Task<int>(() => {
                Thread.Sleep(1000);
                Console.WriteLine("Task 2 ejecutando");
                return 8;
            });

            task1.Start();
            task2.Start();

            Console.WriteLine("Otro proceso");

            var result = await task1;
            var result2 = await task2;

            Console.WriteLine("Proceso terminado");

            stopWatch.Stop();
            return Ok("task 1 result: " + result + " Task 2 result: " + result2 + " Time: " + stopWatch.Elapsed);
        }
    }
}
