using Domain.Event;
using Infrastructure.Data.Interfaces.Mongo;
using Infrastructure.Data.Messaging.BackgroundsQueue.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Data.Messaging.BackgroundsQueue
{
    public class NutricionistaEventQueue : BaseQueue<NutricionistaEvent>
    {
        public NutricionistaEventQueue(
            IConfiguration configuration,
            IMongoDbContext mongoDbContext) : base(configuration, mongoDbContext) { }

        public override void QueueController(NutricionistaEvent evento)
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
