using Domain.Event;
using Infrastructure.Data.Interfaces.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<UserEvent> mongoCollection;

        public UserService(IMongoDbContext mongoDbContext)
        {
            var queName = nameof(UserEvent).Replace("Event", "");
            mongoCollection = mongoDbContext
                .GetDatabase(queName)
                .GetCollection<UserEvent>(queName);
        }

        public async Task<bool> VerificarEmailExiste(string email)
        {
            return await mongoCollection.Find(new BsonDocument("Email", email)).AnyAsync();
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
