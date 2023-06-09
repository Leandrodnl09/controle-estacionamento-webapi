using ControleEstacionamento.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamento.WebApi.Controllers
{
    [ApiController]
    [Route("api/modelos")]
    public class CarrosModeloController : Controller
    {
        private static List<CarrosModeloModel> _carrosModeloModels = new List<CarrosModeloModel>()
        {
            new CarrosModeloModel()
            {
                Id = 1,
                Ano = 2022,
                Marca = "Fiat",
                Modelo = "Uno"
            },

            new CarrosModeloModel()
            {
                Id = 2,
                Ano = 2021,
                Marca = "Volkswagem",
                Modelo = "Gol"
            },

            new CarrosModeloModel()
            {
                Id = 3,
                Ano = 2020,
                Marca = "Chevrolet",
                Modelo = "Monza"
            },

            new CarrosModeloModel()
            {
                Id = 4,
                Ano = 2019,
                Marca = "Ford",
                Modelo = "Fiesta"
            },
        };

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(_carrosModeloModels);
        }

        [HttpGet("ano/{ano}")]
        public async Task<ActionResult> GetByYear([FromRoute] int ano)
        {
            var modelos = _carrosModeloModels.Where(c => c.Ano == ano).ToList();
            return Ok(modelos); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var modelo = _carrosModeloModels.Where(c =>c.Id == id).FirstOrDefault();

            if (modelo == null)
                return NotFound();

            return Ok(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CarrosModeloModel model)
        {
            _carrosModeloModels.Add(model);
            return Ok(model);
        }
    }
}
