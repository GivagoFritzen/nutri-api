using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Base;
using Domain.Interface.Repository.Mongo;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public class NutricionistaRepository : RepositoryBase<NutricionistaEntity, NutricionistaEvent>, INutricionistaRepository
    {
        public NutricionistaRepository(IRepositorySQL<NutricionistaEntity> repositoryNutricionista, IMongoDbContext mongoDbContext)
            : base(repositoryNutricionista, mongoDbContext)
        {
            repositorySQL = repositoryNutricionista;
        }
    }
}