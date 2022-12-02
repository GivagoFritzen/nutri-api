using Domain.Entity;
using Domain.Interface.Event;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository.Base
{
    public interface IRepositoryBase<TEntity, TEvent>
            where TEntity : BaseEntity
            where TEvent : IEvent
    {
        Task AddAsync(TEntity obj);
        void Update(TEntity obj);
        Task UpdateMongoByFilter(FilterDefinition<TEvent> filter, UpdateDefinition<TEvent> update);
        Task RemoveById(Guid id);
        Task<IEnumerable<TEvent>> GetAll();
        Task<IEnumerable<TEvent>> GetAll(ProjectionDefinition<TEvent> fields);
        Task<IEnumerable<TEvent>> GetAll(FilterDefinition<TEvent> filter, ProjectionDefinition<TEvent> fields);
        Task<TEvent> GetById(Guid id);
        Task<TEvent> GetByEmail(string email);
    }
}
