using Domain.Entity;
using Domain.Event;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IServiceBase<TEntity, TEvent>
        where TEntity : BaseEntity
        where TEvent : UserEvent
    {
        Task AddAsync(TEntity obj);
        void Update(TEntity obj);
        Task RemoveById(Guid id);
        Task<IEnumerable<TEvent>> GetAll();
        Task<IEnumerable<TEvent>> GetAll(ProjectionDefinition<TEvent> fields);
        Task<TEvent> GetById(Guid id);
        Task<TEvent> GetByEmail(string email);
    }
}