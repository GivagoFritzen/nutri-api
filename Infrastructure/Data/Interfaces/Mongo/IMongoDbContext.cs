using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces.Mongo
{
    public interface IMongoDbContext
    {
        IClientSessionHandle Session { get; set; }

        void AddCommand(Func<Task> func);
        void Dispose();
        IMongoDatabase GetDatabase(string name);
        IMongoCollection<T> GetCollection<T>(string name);
        Task<int> SaveChanges();
    }
}