using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.SQL.Mapper
{
    public static class PacienteEntityMapper
    {
        public static void PacienteMap(this ModelBuilder modelBuilder)
        {
            var pacienteBuilder = modelBuilder.Entity<PacienteEntity>();

            pacienteBuilder.ToTable("Pacientes");
        }
    }
}
