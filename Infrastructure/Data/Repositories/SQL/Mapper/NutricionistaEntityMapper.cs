using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.SQL.Mapper
{
    public static class NutricionistaEntityMapper
    {
        public static void NutricionistaMap(this ModelBuilder modelBuilder)
        {
            var nutricionistaBuilder = modelBuilder.Entity<NutricionistaEntity>();

            nutricionistaBuilder
                .HasMany(x => x.Pacientes)
                .WithOne(m => m.Nutricionista)
                .HasForeignKey(m => m.NutricionistaEntityId);

            nutricionistaBuilder.ToTable("Nutricionistas");
        }
    }
}
