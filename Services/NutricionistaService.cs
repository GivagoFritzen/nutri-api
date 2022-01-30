using Core.Interfaces.Services;
using Domain.Entity;
using Domain.Event;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Interfaces.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using Services.Base;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class NutricionistaService : ServiceBase<NutricionistaEntity, NutricionistaEvent>, INutricionistaService
    {
        public NutricionistaService(IRepositoryBase<NutricionistaEntity> repositoryNutricionista, IMongoDbContext mongoDbContext)
            : base(repositoryNutricionista, mongoDbContext)
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