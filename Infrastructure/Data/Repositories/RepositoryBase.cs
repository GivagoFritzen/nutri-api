﻿using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DataContext context;

        public RepositoryBase(DataContext context)
        {
            this.context = context;
        }

        public void Add(TEntity obj)
        {
            try
            {
                context.Set<TEntity>().Add(obj);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                context.Entry(obj).State = EntityState.Modified;
                context.Set<TEntity>().Update(obj);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}