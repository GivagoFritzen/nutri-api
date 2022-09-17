using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.SQL.Mapper
{
    public static class RefeicaoEntityMapper
    {
        public static void RefeicaoMap(this ModelBuilder modelBuilder)
        {
            var refeicaoBuilder = modelBuilder.Entity<RefeicaoEntity>();

            refeicaoBuilder
                .HasMany(x => x.Alimentos)
                .WithOne(r => r.Refeicao)
                .HasForeignKey(x => x.RefeicaoEntityId);

            refeicaoBuilder.ToTable("RefeicaoEntity");
        }
    }
}
