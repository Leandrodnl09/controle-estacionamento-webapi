using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamento.WebApi.Controllers
{
    public class ControlePermanenciaCarroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
