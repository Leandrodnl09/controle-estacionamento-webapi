using ControleEstacionamento.WebApi.Database;
using ControleEstacionamento.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleEstacionamento.WebApi.Controllers
{
    [ApiController]
    [Route("api/modelos")]
    public class CarrosModeloController : Controller
    {
        private readonly DataContext _dataContext;

        public CarrosModeloController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var carrosModelo = _dataContext.CarrosModelo.ToList();
            return Ok(carrosModelo);
        }

        [HttpGet("ano/{ano}")]
        public async Task<ActionResult> GetByYear([FromRoute] int ano)
        {
            var modelos = _dataContext.CarrosModelo.Where(c => c.Ano == ano).ToList();
            return Ok(modelos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var carro = await _dataContext.CarrosModelo.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (carro == null)
                return NotFound();

            return Ok(carro);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CarrosModeloModel model)
        {
            _dataContext.CarrosModelo.Add(model);
            await _dataContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var modelo = await _dataContext.CarrosModelo.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (modelo != null)
            {
                _dataContext.CarrosModelo.Remove(modelo);
                await _dataContext.SaveChangesAsync();
                return Ok("O modelo foi deletado!");
            }
            else
            {
                return NotFound("Não foi possivel encontrar o modelo!");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CarrosModeloModel model)
        {
            var modelo = await _dataContext.CarrosModelo.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (modelo != null)
            {
                modelo.Ano = model.Ano;
                modelo.Modelo = model.Modelo;
                modelo.Marca = model.Marca;
                await _dataContext.SaveChangesAsync();
                return Ok("O modelo foi atualizado!");
            }
            else
            {
                return NotFound("Não foi possivel encontrar o modelo!");
            }
        }
    }
}
