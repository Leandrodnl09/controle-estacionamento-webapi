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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var modelo = controlePermanenciaCarros.Where(c => c.Id == id).FirstOrDefault();

            if (modelo == null)
                return NotFound();

            return Ok(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ControlePermanenciaCarrosModel model)
        {
            controlePermanenciaCarros.Add(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var modelo = controlePermanenciaCarros.Where(c => c.Id == id).FirstOrDefault();

            if(modelo != null)
            {
                controlePermanenciaCarros.Remove(modelo);
                return Ok("Permanência do veículo removido com sucesso!");
            }
            else
            {
                return NotFound("Não foi possivel remover a permanência do veículo!");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ControlePermanenciaCarrosModel model)
        {
            var modelo = controlePermanenciaCarros.Where(c =>c.Id == id).FirstOrDefault();

            if (modelo != null)
            {
                var indexOf = controlePermanenciaCarros.IndexOf(modelo);
                controlePermanenciaCarros[indexOf] = model;
                return Ok("O controle de permanência foi atualizado com sucesso!");
            }
            else
            {
                return NotFound("Não foi possivel encontrar o controle de permanência!");
            }
        }
    }
}
