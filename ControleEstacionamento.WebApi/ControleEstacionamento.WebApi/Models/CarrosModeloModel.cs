using System.Security.Principal;

namespace ControleEstacionamento.WebApi.Models
{
    public class CarrosModeloModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
    }
}
