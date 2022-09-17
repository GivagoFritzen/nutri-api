using Domain.Entity.Medidas;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.SQL.Mapper
{
    public static class CircuferenciaEntityMapper
    {
        public static void CircuferenciaMap(this ModelBuilder modelBuilder)
        {
            var circuferenciaBuilder = modelBuilder.Entity<CircunferenciaEntity>();

            circuferenciaBuilder.ToTable("CircuferenciaEntity");
        }
    }
}
