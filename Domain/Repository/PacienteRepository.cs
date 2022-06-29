using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Base;
using Domain.Interface.Repository.Mongo;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class PacienteRepository : RepositoryBase<PacienteEntity, PacienteEvent>, IPacienteRepository
    {
        public PacienteRepository(IRepositorySQL<PacienteEntity> repositoryPaciente, IMongoDbContext mongoDbContext)
            : base(repositoryPaciente, mongoDbContext)
        {
            repositorySQL = repositoryPaciente;
        }

        public async Task<IEnumerable<PlanoAlimentarEntity>> GetPlanosByPacienteId(Guid pacienteId)
        {
            var paciente = await repositorySQL.GetById(pacienteId);
            return paciente.PlanosAlimentares;
        }

        public async Task<IEnumerable<MedidaEntity>> GetMedidasByPacienteId(Guid pacienteId)
        {
            var paciente = await repositorySQL.GetById(pacienteId);
            return paciente.Medidas;
        }
    }
}