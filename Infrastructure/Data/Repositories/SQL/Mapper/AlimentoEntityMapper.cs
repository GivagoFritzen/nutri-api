using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.SQL.Mapper
{
    public static class AlimentoEntityMapper
    {
        public static void AlimentoMap(this ModelBuilder modelBuilder)
        {
            var alimentoBuilder = modelBuilder.Entity<AlimentoEntity>();

            alimentoBuilder
                .HasOne(x => x.Refeicao)
                .WithMany(m => m.Alimentos)
                .HasForeignKey(m => m.RefeicaoEntityId);

            alimentoBuilder.ToTable("AlimentoEntity");
        }
    }
}
