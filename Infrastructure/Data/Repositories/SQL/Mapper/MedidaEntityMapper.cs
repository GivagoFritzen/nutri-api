using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.SQL.Mapper
{
    public static class MedidaEntityMapper
    {
        public static void MedidaMap(this ModelBuilder modelBuilder)
        {
            var medidaBuilder = modelBuilder.Entity<MedidaEntity>();

            medidaBuilder
                .HasOne(x => x.Circunferencia)
                .WithOne(c => c.Medida)
                .HasForeignKey<MedidaEntity>(x => x.CircunferenciaId);

            medidaBuilder
                .HasOne(x => x.Paciente)
                .WithMany(m => m.Medidas)
                .HasForeignKey(x => x.PacienteEntityId);

            medidaBuilder.ToTable("MedidaEntity");
        }
    }
}
