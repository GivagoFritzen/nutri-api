using CrossCutting.Helpers;
using CrossCutting.Message.Exceptions;
using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository.Base;
using Domain.Interface.Repository.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository.Base
{
    public class RepositoryBase<TEntity, TEvent> : IRepositoryBase<TEntity, TEvent>
        where TEntity : BaseEntity
        where TEvent : UserEvent
    {
        protected IRepositorySQL<TEntity> repositorySQL;
        protected readonly IMongoCollection<TEvent> mongoCollection;

        public RepositoryBase(
            IRepositorySQL<TEntity> repositorySQL,
            IMongoDbContext mongoDbContext)
        {
            this.repositorySQL = repositorySQL;

            var queName = StringHelper.GetEventName(typeof(TEvent).Name);

            mongoCollection = mongoDbContext
                .GetDatabase()
                .GetCollection<TEvent>(queName);
        }

        public async Task AddAsync(TEntity obj)
        {
            await repositorySQL.AddAsync(obj);
        }

        public async Task<IEnumerable<TEvent>> GetAll()
        {
            return await mongoCollection.Aggregate().ToListAsync();
        }

        public async Task<IEnumerable<TEvent>> GetAll(ProjectionDefinition<TEvent> fields)
        {
            return await mongoCollection.Aggregate().Project<TEvent>(fields).ToListAsync();
        }

        public async Task<IEnumerable<TEvent>> GetAll(FilterDefinition<TEvent> filter, ProjectionDefinition<TEvent> fields)
        {
            return await mongoCollection.Find(filter)
                .Project<TEvent>(fields)
                .ToListAsync();
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
            await repositorySQL.RemoveById(id);
        }

        public void Update(TEntity obj)
        {
            repositorySQL.Update(obj);
        }
    }
}