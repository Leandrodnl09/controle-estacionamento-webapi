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
        public async Task<ActionResult> GetAllAsync()
        {
            var modelo = await _dataContext.ControlePermanenciaCarros.ToListAsync();
            return Ok(modelo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var modelo = await _dataContext.ControlePermanenciaCarros.Where(c => c.Id == id).FirstOrDefaultAsync();

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var modelo = await _dataContext.ControlePermanenciaCarros.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (modelo != null)
            {
                _dataContext.ControlePermanenciaCarros.Remove(modelo);
                await _dataContext.SaveChangesAsync();
                return Ok("O controle de permanência foi deletado!");
            }
            else
            {
                return NotFound("Não foi possivel encontrar o controle de permanência!");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ControlePermanenciaCarrosModel model)
        {
            var modelo = await _dataContext.ControlePermanenciaCarros.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (modelo != null)
            {
                modelo.Placa = model.Placa;
                modelo.IdModelo = model.IdModelo;
                modelo.DataHoraEntrada = model.DataHoraEntrada;
                await _dataContext.SaveChangesAsync();
                return Ok("O controle de permanência foi atualizado com sucesso!");
            }
            else
            {
                return NotFound("Não foi possivel encontrar o controle de permanência!");
            }
        }

        [HttpPut("/finalizarpermanencia/{id}")]
        public async Task<ActionResult> Update([FromRoute] int id)
        {
            try
            {
                var modelo = await _dataContext.ControlePermanenciaCarros.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (modelo != null)
                {
                    modelo.DataHoraSaida = DateTime.Now;
                    await _dataContext.SaveChangesAsync();
                    return Ok("O controle de permanência foi finalizado com sucesso!");
                }
                else
                {
                    return NotFound("Não foi possivel encontrar o controle de permanência!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost("/calculartempodepermanencia/{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] PrecoPermanenciaModel model)
        {
            try
            {
                var modelo = await _dataContext.ControlePermanenciaCarros.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (modelo != null)
                {
                    var tempoTotal = modelo.DataHoraSaida - modelo.DataHoraEntrada;
                    var horas = tempoTotal.Value.TotalHours;

                    if (horas <= 0.59)
                    {
                        horas = 1.00;
                    }
                    else
                    {
                        horas = Math.Ceiling(horas);
                    }
                    return Ok("O valor da permanência " + (horas * model.ValorHora).ToString("0.##"));
                }
                else
                {
                    return NotFound("Não foi possivel encontrar o controle de permanência!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}

            