using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Base;
using Domain.Interface.Repository.Mongo;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public class PacienteRepository : RepositoryBase<PacienteEntity, PacienteEvent>, IPacienteRepository
    {
        public PacienteRepository(IRepositorySQL<PacienteEntity> repositoryPaciente, IMongoDbContext mongoDbContext)
            : base(repositoryPaciente, mongoDbContext)
        {
            repositorySQL = repositoryPaciente;
        }
    }
}