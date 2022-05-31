using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data.SQL
{
    public class SQLDataContext : DbContext
    {
        public DbSet<PacienteEntity> Pacientes { get; set; }
        public DbSet<NutricionistaEntity> Nutricionistas { get; set; }

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
    }
}