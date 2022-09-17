using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.SQL.Mapper
{
    public static class PlanoAlimentarEntityMapper
    {
        public static void PlanoAlimentarMap(this ModelBuilder modelBuilder)
        {
            var planoAlimentarBuilder = modelBuilder.Entity<PlanoAlimentarEntity>();

            planoAlimentarBuilder
                .HasMany(x => x.Refeicoes)
                .WithOne(r => r.PlanoAlimentar)
                .HasForeignKey(x => x.PlanoAlimentarEntityId);

            planoAlimentarBuilder.ToTable("PlanoAlimentarEntity");
        }
    }
}
