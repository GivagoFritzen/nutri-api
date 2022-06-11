using Domain.DTO.Taco;
using Domain.Event.Taco;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class TacoRepository : ITacoRepository
    {
        private readonly IMongoCollection<TacoEvent> mongoCollection;

        public TacoRepository(IMongoDbContext mongoDbContext)
        {
            var queName = nameof(TacoEvent).Replace("Event", "");
            mongoCollection = mongoDbContext
                .GetDatabase()
                .GetCollection<TacoEvent>(queName);
        }

        public async Task<TacoPaginationDTO> GetDescricao(string descricao, int paginaAtual, int tamanhoPagina)
        {
            var filter = Builders<TacoEvent>.Filter.Regex(
                     "description",
                     new BsonRegularExpression(descricao));

            var data = await mongoCollection.Find(filter)
                .Skip((paginaAtual - 1) * tamanhoPagina)
                .Limit(tamanhoPagina)
                .ToListAsync();

            var totalItens = await mongoCollection.CountDocumentsAsync(filter);

            return new TacoPaginationDTO()
            {
                Data = data,
                Total = (int)totalItens
            };
        }
    }
}
