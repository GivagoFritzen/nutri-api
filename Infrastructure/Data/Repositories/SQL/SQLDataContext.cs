using Domain.Entity;
using Domain.Entity.Medidas;
using Infrastructure.Data.Repositories.SQL.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data.SQL
{
    public class SQLDataContext : DbContext
    {
        public DbSet<PacienteEntity> Pacientes { get; set; }
        public DbSet<NutricionistaEntity> Nutricionistas { get; set; }
        public DbSet<MedidaEntity> Medidas { get; set; }
        public DbSet<PlanoAlimentarEntity> PlanoAlimentares { get; set; }
        public DbSet<CircunferenciaEntity> Circunferencias { get; set; }

        public SQLDataContext(DbContextOptions<SQLDataContext> options)
        : base(options) { }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.PacienteMap();
            modelBuilder.NutricionistaMap();
            modelBuilder.MedidaMap();
            modelBuilder.PlanoAlimentarMap();
            modelBuilder.RefeicaoMap();
            modelBuilder.AlimentoMap();
            modelBuilder.CircuferenciaMap();
        }
    }
}