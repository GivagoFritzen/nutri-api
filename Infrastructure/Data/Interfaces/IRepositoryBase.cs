using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);
    }
}