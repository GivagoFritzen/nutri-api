using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces.Mongo
{
    public interface IMongoDbContext
    {
        MongoClient MongoClient { get; set; }
        IClientSessionHandle Session { get; set; }

        void AddCommand(Func<Task> func);
        void Dispose();
        IMongoCollection<T> GetCollection<T>(string name);
        Task<int> SaveChanges();
    }
}