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
            }

            new CarrosModeloModel()
            {
                Id = 2,
                Ano = 2021,
                Marca = "Volkswagem",
                Modelo = "Gol"
            }

            new CarrosModeloModel()
            {
                Id = 3,
                Ano = 2020,
                Marca = "Chevrolet",
                Modelo = "Monza"
            }

            new CarrosModeloModel()
            {
                Id = 4,
                Ano = 2019,
                Marca = "Ford",
                Modelo = "Fiesta"
            }
        };
    }
}
