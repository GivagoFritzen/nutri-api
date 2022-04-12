using Core.Interfaces.Services;
using Domain.Entity;
using Domain.Event;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Interfaces.Mongo;
using Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class PacienteService : ServiceBase<PacienteEntity, PacienteEvent>, IPacienteService
    {
        public PacienteService(IRepositoryBase<PacienteEntity> repositoryPaciente, IMongoDbContext mongoDbContext)
            : base(repositoryPaciente, mongoDbContext)
        {
            repository = repositoryPaciente;
        }

        public async Task<IEnumerable<PacienteEntity>> GetAllByListIdAsync(List<Guid> pacientesId)
        {
            var allPacientes = await repository.GetAll();
            return allPacientes.Where(x => pacientesId.Contains(x.Id));
        }
    }
}