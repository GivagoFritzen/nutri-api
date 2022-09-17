using CrossCutting.Message.Exceptions;
using Domain.Entity;
using Domain.Interface.Repository.Base;
using Infrastructure.Data.SQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories.SQL
{
    public class RepositorySQLBase<TEntity> : IRepositorySQL<TEntity> where TEntity : class
    {
        protected readonly SQLDataContext context;

        public RepositorySQLBase(SQLDataContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(TEntity obj)
        {
            try
            {
                await context.Set<TEntity>().AddAsync(obj);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"{ExceptionsMessages.NaoFoiPossivelCadastrar} - {e.Message}");
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllWithInclude(string include)
        {
            return await context.Set<TEntity>()
                .Include(include)
                .ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveById(Guid id)
        {
            try
            {
                var obj = await context.Set<TEntity>().FindAsync(id);
                context.Set<TEntity>().Attach(obj);
                context.Set<TEntity>().Remove(obj);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"{ExceptionsMessages.NaoFoiPossivelDeletar} - {e.Message}");
            }
        }

        public void Update(BaseEntity obj)
        {
            try
            {
                var current = context.Set<TEntity>().Find(obj.Id);
                context.Entry(current).CurrentValues.SetValues(obj);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"{ExceptionsMessages.NaoFoiPossivelAtualizar} - {e.Message}");
            }
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}