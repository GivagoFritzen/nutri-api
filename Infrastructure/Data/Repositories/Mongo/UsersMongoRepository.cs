using Domain.Event;
using Infrastructure.Data.Interfaces.Mongo;
using MongoDB.Driver;

namespace Infrastructure.Data.Repositories.Mongo
{
    public class UsersMongoRepository : IUsersMongoRepository
    {
        private IMongoCollection<UserEvent> _users;

        public UsersMongoRepository(IMongoClient client)
        {
            var database = client.GetDatabase("MongoConnectionString");
            var collection = database.GetCollection<UserEvent>(nameof(UserEvent));
            _users = collection;
        }

        public void Create(string email)
        {
            var user = new UserEvent()
            {
                Email = email,
            };

            _users.InsertOne(user);
        }

        public void Remove(string email)
        {
            var filter = Builders<UserEvent>.Filter.Where(_ => _.Email == email);
            var operation = _users.DeleteOne(filter);
        }

        public UserEvent GetUserByEmail(string email)
        {
            return _users.Find(customer => customer.Email == email).SingleOrDefault();
        }
    }
}
