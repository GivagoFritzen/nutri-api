using Domain.Interface.Services;
using Domain.Entity;
using Domain.Event;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Interfaces.Mongo;
using Services.Base;

namespace Services
{
    public class PacienteService : ServiceBase<PacienteEntity, PacienteEvent>, IPacienteService
    {
        public PacienteService(IRepositoryBase<PacienteEntity> repositoryPaciente, IMongoDbContext mongoDbContext)
            : base(repositoryPaciente, mongoDbContext)
        {
            repository = repositoryPaciente;
        }
    }
}