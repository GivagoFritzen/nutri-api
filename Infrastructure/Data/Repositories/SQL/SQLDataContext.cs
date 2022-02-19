﻿using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data.SQL
{
    public class SQLDataContext : DbContext
    {
        public DbSet<AdminsEntity> Admins { get; set; }
        public DbSet<PacienteEntity> Pacientes { get; set; }
        public DbSet<NutricionistaEntity> Nutricionistas { get; set; }

        public SQLDataContext(DbContextOptions<SQLDataContext> options)
        : base(options) { }

        public override int SaveChanges()
        {
            /*
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            */

            return base.SaveChanges();
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}