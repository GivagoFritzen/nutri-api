using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Domain.Interface.Repository.Mongo
{
    public interface IMongoDbContext
    {
        IClientSessionHandle Session { get; set; }

        void AddCommand(Func<Task> func);
        void Dispose();
        IMongoDatabase GetDatabase();
        IMongoCollection<T> GetCollection<T>(string name);
        Task<int> SaveChanges();
    }
}