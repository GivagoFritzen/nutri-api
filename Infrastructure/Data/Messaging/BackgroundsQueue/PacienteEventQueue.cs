using Domain.Event;
using Domain.Interface.Repository.Mongo;
using Infrastructure.Data.Messaging.BackgroundsQueue.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Data.Messaging.BackgroundsQueue
{
    public class PacienteEventQueue : BaseQueue<PacienteEvent>
    {
        public PacienteEventQueue(
            IConfiguration configuration,
            IMongoDbContext mongoDbContext) : base(configuration, mongoDbContext) { }

        public override void QueueController(PacienteEvent evento)
        {
            if (evento.Delete)
                mongoCollection.DeleteOne(ev => ev.Id == evento.Id);
            else if (evento.Update)
                mongoCollection.ReplaceOne(ev => ev.Id == evento.Id, evento);
            else
                mongoCollection.InsertOne(evento);
        }
    }
}
