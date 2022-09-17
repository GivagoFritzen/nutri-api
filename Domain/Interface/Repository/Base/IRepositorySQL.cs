using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository.Base
{
    public interface IRepositorySQL<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        void Update(BaseEntity obj);
        Task RemoveById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllWithInclude(string include);
        Task<TEntity> GetById(Guid id);
    }
}
