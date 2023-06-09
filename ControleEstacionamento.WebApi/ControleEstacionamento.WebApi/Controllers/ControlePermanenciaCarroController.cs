using ControleEstacionamento.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamento.WebApi.Controllers
{
    [ApiController]
    [Route("api/controlepermanencia")]
    public class ControlePermanenciaCarroController : Controller
    {
        private static List<ControlePermanenciaCarrosModel> controlePermanenciaCarros = new List<ControlePermanenciaCarrosModel>()
        {
            new ControlePermanenciaCarrosModel()
            {
                Id = 1,
                Placa = "AAA-1111",
                IdModelo = 001,
                DataHoraEntrada = new DateTime(2023,06,08,16,03,00)
            },

            new ControlePermanenciaCarrosModel()
            {
                Id = 2,
                Placa = "AAA-2222",
                IdModelo = 002,
                DataHoraEntrada = new DateTime(2023,06,08,16,03,00)
            },

            new ControlePermanenciaCarrosModel()
            {
                Id = 3,
                Placa = "AAA-3333",
                IdModelo = 003,
                DataHoraEntrada = new DateTime(2023,06,08,16,03,00)
            },

            new ControlePermanenciaCarrosModel()
            {
                Id = 4,
                Placa = "AAA-4444",
                IdModelo = 004,
                DataHoraEntrada = new DateTime(2023,06,08,16,03,00)
            }
        };

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(controlePermanenciaCarros);
        }
    }
}
