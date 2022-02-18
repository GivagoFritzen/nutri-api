using Core.Interfaces.Services;
using Domain.Entity;
using Domain.Event;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Interfaces.Mongo;
using Services.Base;

namespace Services
{
    public class NutricionistaService : ServiceBase<NutricionistaEntity, NutricionistaEvent>, INutricionistaService
    {
        public NutricionistaService(IRepositoryBase<NutricionistaEntity> repositoryNutricionista, IMongoDbContext mongoDbContext)
            : base(repositoryNutricionista, mongoDbContext)
        {
            repository = repositoryNutricionista;
        }
    }
}