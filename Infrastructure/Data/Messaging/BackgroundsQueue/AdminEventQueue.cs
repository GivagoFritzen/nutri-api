using Domain.Event;
using Infrastructure.Data.Interfaces.Mongo;
using Infrastructure.Data.Messaging.BackgroundsQueue.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Data.Messaging.BackgroundsQueue
{
    public sealed class AdminEventQueue : BaseQueue<AdminsEvent>
    {
        public AdminEventQueue(
            IConfiguration configuration,
            IMongoDbContext mongoDbContext) : base(configuration, mongoDbContext) { }

        public override void QueueController(AdminsEvent evento)
        {
            if (evento.Delete)
                mongoCollection.DeleteOne(ev => ev.Id == evento.Id);
            if (evento.Update)
                mongoCollection.ReplaceOne(ev => ev.Id == evento.Id, evento);
            else
                mongoCollection.InsertOne(evento);
        }
    }
}
