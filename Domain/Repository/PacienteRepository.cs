using Domain.DTO.Paciente;
using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Base;
using Domain.Interface.Repository.Mongo;
using Domain.Repository.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class PacienteRepository : RepositoryBase<PacienteEntity, PacienteEvent>, IPacienteRepository
    {
        private const int tamanhoPagina = 10;

        public PacienteRepository(IRepositorySQL<PacienteEntity> repositoryPaciente, IMongoDbContext mongoDbContext)
            : base(repositoryPaciente, mongoDbContext)
        {
            repositorySQL = repositoryPaciente;
        }

        public async Task<PacientePaginationDTO> GetAll(string email, int paginaAtual)
        {
            var filter = Builders<PacienteEvent>.Filter.Regex(
                 "Email",
                 new BsonRegularExpression(email));

            var data = await mongoCollection.Aggregate()
                .Skip((paginaAtual - 1) * tamanhoPagina)
                .Limit(tamanhoPagina)
                .ToListAsync();

            var totalItens = await mongoCollection.CountDocumentsAsync(filter);

            return new PacientePaginationDTO()
            {
                Data = data,
                Total = (int)totalItens
            };
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