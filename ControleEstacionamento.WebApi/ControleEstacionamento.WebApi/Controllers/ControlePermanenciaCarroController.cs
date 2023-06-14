using ControleEstacionamento.WebApi.Database;
using ControleEstacionamento.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleEstacionamento.WebApi.Controllers
{
    [ApiController]
    [Route("api/controlepermanencia")]
    public class ControlePermanenciaCarroController : Controller
    {
        private readonly DataContext _dataContext;

        public ControlePermanenciaCarroController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var modelo = _dataContext.ControlePermanenciaCarros.ToListAsync();
            return Ok(modelo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var modelo = _dataContext.ControlePermanenciaCarros.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (modelo == null)
                return NotFound();

            return Ok(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ControlePermanenciaCarrosModel model)
        {
            _dataContext.ControlePermanenciaCarros.Add(model);
            await _dataContext.SaveChangesAsync();
            return Ok(model);
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete([FromRoute] int id)
        //{
        //    var modelo = controlePermanenciaCarros.Where(c => c.Id == id).FirstOrDefault();

        //    if(modelo != null)
        //    {
        //        controlePermanenciaCarros.Remove(modelo);
        //        return Ok("Permanência do veículo removido com sucesso!");
        //    }
        //    else
        //    {
        //        return NotFound("Não foi possivel remover a permanência do veículo!");
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ControlePermanenciaCarrosModel model)
        //{
        //    var modelo = controlePermanenciaCarros.Where(c =>c.Id == id).FirstOrDefault();

        //    if (modelo != null)
        //    {
        //        var indexOf = controlePermanenciaCarros.IndexOf(modelo);
        //        controlePermanenciaCarros[indexOf] = model;
        //        return Ok("O controle de permanência foi atualizado com sucesso!");
        //    }
        //    else
        //    {
        //        return NotFound("Não foi possivel encontrar o controle de permanência!");
        //    }
        //}
    }
}
