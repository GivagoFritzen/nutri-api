using Core.Interfaces.Services;
using CrossCutting.Helpers;
using CrossCutting.Message.Exceptions;
using Domain.Entity;
using Domain.Event;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Interfaces.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Base
{
    public class ServiceBase<TEntity, TEvent> : IServiceBase<TEntity, TEvent>
        where TEntity : BaseEntity
        where TEvent : UserEvent
    {
        protected IRepositoryBase<TEntity> repository;
        protected readonly IMongoCollection<TEvent> mongoCollection;

        public ServiceBase(
            IRepositoryBase<TEntity> repository,
            IMongoDbContext mongoDbContext)
        {
            this.repository = repository;

            var queName = StringHelper.GetEventName(typeof(TEvent).Name);

            mongoCollection = mongoDbContext
                .GetDatabase(queName)
                .GetCollection<TEvent>(queName);
        }

        public async Task AddAsync(TEntity obj)
        {
            await repository.AddAsync(obj);
        }

        public async Task<IEnumerable<TEvent>> GetAll()
        {
            return await mongoCollection.Aggregate().ToListAsync();
        }

        public async Task<IEnumerable<TEvent>> GetAll(ProjectionDefinition<TEvent> fields)
        {
            return await mongoCollection.Aggregate().Project<TEvent>(fields).ToListAsync();
        }

        public async Task<TEvent> GetById(Guid id)
        {
            var filter = Builders<TEvent>.Filter.Eq(x => x.Id, id);
            var @event = await mongoCollection.Find(filter).FirstOrDefaultAsync();

            if (@event == null)
                throw new InvalidOperationException($"{ExceptionsMessages.UsuarioNaoEncontrado}");

            return @event;
        }

        public async Task<TEvent> GetByEmail(string email)
        {
            var filter = Builders<TEvent>.Filter.Eq(x => x.Email, email);
            var @event = await mongoCollection.Find(filter).FirstOrDefaultAsync();

            if (@event == null)
                throw new InvalidOperationException($"{ExceptionsMessages.UsuarioNaoEncontrado}");

            return @event;
        }

        public async Task RemoveById(Guid id)
        {
            await repository.RemoveById(id);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}