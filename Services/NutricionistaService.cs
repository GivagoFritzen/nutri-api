using Core.Interfaces.Services;
using Domain.Entity;
using Domain.Event;
using Infrastructure.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Services.Base;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class NutricionistaService : ServiceBase<NutricionistaEntity>, INutricionistaService
    {
        private readonly IMongoCollection<UserEvent> mongoCollection;

        public NutricionistaService(IRepositoryBase<NutricionistaEntity> repositoryNutricionista)
            : base(repositoryNutricionista)
        {
            repository = repositoryNutricionista;
        }

        public async Task<bool> VerificarEmailExiste(string email)
        {
            return await mongoCollection.Find(new BsonDocument("Email", email)).AnyAsync();
        }

        public async Task<bool> VerificarEmailExiste(string email, Guid currentId)
        {
            var currentUser = (await mongoCollection.FindAsync(user => user.Id == currentId)).FirstOrDefault();
            if (currentUser != null && currentUser.Email != email)
                return await mongoCollection.Find(new BsonDocument("Email", email)).AnyAsync();

            return false;
        }
    }
}