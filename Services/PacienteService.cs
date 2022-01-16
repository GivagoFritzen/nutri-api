using Core.Interfaces.Services;
using Domain.Entity;
using Domain.Event;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Interfaces.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using Services.Base;
using System.Threading.Tasks;

namespace Services
{
    public class PacienteService : ServiceBase<PacienteEntity>, IPacienteService
    {
        private readonly IMongoCollection<UserEvent> mongoCollection;

        public PacienteService(IRepositoryBase<PacienteEntity> repositoryPaciente, IMongoDbContext mongoDbContext)
            : base(repositoryPaciente)
        {
            var queName = nameof(UserEvent).Replace("Event", "");
            mongoCollection = mongoDbContext
                .GetDatabase(queName)
                .GetCollection<UserEvent>(queName);

            repository = repositoryPaciente;
        }

        public async Task<bool> VerificarEmailExiste(string email)
        {
            return await mongoCollection.Find(new BsonDocument("Email", email)).AnyAsync();
        }
    }
}