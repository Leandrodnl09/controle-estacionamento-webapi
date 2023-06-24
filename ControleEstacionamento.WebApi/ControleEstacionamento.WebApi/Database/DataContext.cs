using ControleEstacionamento.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstacionamento.WebApi.Database
{
    public class DataContext : DbContext
    {
        public DbSet<CarrosModeloModel> CarrosModelo { get; set; }

        public DbSet<ControlePermanenciaCarrosModel> ControlePermanenciaCarros { get; set; }    

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
