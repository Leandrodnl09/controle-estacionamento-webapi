namespace ControleEstacionamento.WebApi.Models
{
    public class ControlePermanenciaCarrosModel
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int IdModelo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
    }
}
