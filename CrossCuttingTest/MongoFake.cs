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
            return client.GetDatabase(GetName());
        }

        public async Task<IMongoCollection<TEvent>> GetCollection()
        {
            var client = new MongoClient(runner.ConnectionString);
            var database = client.GetDatabase(GetName());
            var collection = database.GetCollection<TEvent>(GetName());
            await collection.InsertManyAsync(ReadFiles());

            return collection;
        }

        private string GetName()
        {
            return typeof(TEvent).Name
                .Replace("Event", "")
                .Replace("Entity", "");
        }

        private List<TEvent> ReadFiles()
        {
            var path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            for (int i = 0; i < 3; i++)
                path = Directory.GetParent(path).FullName;

            path = path.Remove(path.LastIndexOf('\\'));
            path += "\\CrossCuttingTest";

            path += $@"\Fakes\{GetName()}.json";
            path = File.ReadAllText(path);

            return BsonSerializer.Deserialize<List<TEvent>>(path);
        }
    }
}
