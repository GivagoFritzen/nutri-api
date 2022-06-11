using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEvent> mongoCollection;

        public UserRepository(IMongoDbContext mongoDbContext)
        {
            var queName = nameof(UserEvent).Replace("Event", "");
            mongoCollection = mongoDbContext
                .GetDatabase()
                .GetCollection<UserEvent>(queName);
        }

        public async Task<bool> VerificarEmailExiste(string email)
        {
            return await mongoCollection.Find(new BsonDocument("Email", email)).AnyAsync();
        }

        public async Task<bool> VerificarEmailExiste(string email, string type)
        {
            var filter = Builders<UserEvent>.Filter.And(
                Builders<UserEvent>.Filter.Where(p => p.Email.Equals(email)),
                Builders<UserEvent>.Filter.Where(p => p.Type.Equals(type)));

            return await mongoCollection.Find(filter).AnyAsync();
        }

        public async Task<bool> VerificarEmailExiste(string email, Guid currentId)
        {
            var currentUser = (await mongoCollection.FindAsync(user => user.Id == currentId)).FirstOrDefault();
            if (currentUser != null && currentUser.Email != email)
                return await VerificarEmailExiste(email);

            return false;
        }
    }
}
