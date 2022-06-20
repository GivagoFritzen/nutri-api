using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository.Base
{
    public interface IRepositorySQL<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        void Update(TEntity obj);
        Task RemoveById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
    }
}
