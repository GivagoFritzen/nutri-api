using CrossCutting.Message.Exceptions;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.SQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories.SQL
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SQLDataContext context;

        public RepositoryBase(SQLDataContext context)
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

        public void Update(TEntity obj)
        {
            try
            {
                context.Set<TEntity>().Update(obj);
                context.Entry(obj).State = EntityState.Modified;

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