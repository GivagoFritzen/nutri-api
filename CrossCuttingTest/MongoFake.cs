using CrossCutting.Helpers;
using CrossCuttingTest.Interfaces;
using Domain.Interface;
using Mongo2Go;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CrossCuttingTest
{
    public class MongoFake<TEvent> : IMongoFake<TEvent> where TEvent : IEvent
    {
        private MongoDbRunner runner;

        public MongoFake()
        {
            runner = MongoDbRunner.Start();
        }

        public void Dispose()
        {
            runner.Dispose();
        }

        public IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(runner.ConnectionString);
            return client.GetDatabase(StringHelper.GetEventName(typeof(TEvent).Name));
        }

        public async Task<IMongoCollection<TEvent>> GetCollection()
        {
            var client = new MongoClient(runner.ConnectionString);
            var database = client.GetDatabase(StringHelper.GetEventName(typeof(TEvent).Name));
            var collection = database.GetCollection<TEvent>(StringHelper.GetEventName(typeof(TEvent).Name));
            await collection.InsertManyAsync(ReadFiles());

            return collection;
        }

        private List<TEvent> ReadFiles()
        {
            var path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            for (int i = 0; i < 3; i++)
                path = Directory.GetParent(path).FullName;

            path = path.Remove(path.LastIndexOf('\\'));
            path += "\\CrossCuttingTest";

            path += $@"\Fakes\{StringHelper.GetEventName(typeof(TEvent).Name)}.json";
            path = File.ReadAllText(path);

            return BsonSerializer.Deserialize<List<TEvent>>(path);
        }
    }
}
