using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IMongoCollection<TokenEvent> mongoCollection;

        public TokenRepository(IMongoDbContext mongoDbContext)
        {
            var queName = nameof(TokenEvent).Replace("Event", "");
            mongoCollection = mongoDbContext
                .GetDatabase()
                .GetCollection<TokenEvent>(queName);
        }

        public async Task<bool> VerificarRefreshToken(string refreshToken)
        {
            return await mongoCollection.Find(new BsonDocument("RefreshToken", refreshToken)).AnyAsync();
        }

        public void AddRefreshToken(TokenEvent evento)
        {
            mongoCollection.InsertOne(evento);
        }

        public void UpdateRefreshToken(TokenEvent evento, string olderRefreshToken)
        {
            mongoCollection.ReplaceOne(ev => ev.RefreshToken == olderRefreshToken, evento);
        }

        public void DeleteRefreshToken(TokenEvent evento)
        {
            mongoCollection.DeleteOne(ev => ev.RefreshToken == evento.RefreshToken);
        }
    }
}
