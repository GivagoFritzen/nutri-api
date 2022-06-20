using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IPacienteRepository : IRepositoryBase<PacienteEntity, PacienteEvent>
    {
        Task<IEnumerable<PlanoAlimentarEntity>> GetPlanosByPacienteId(Guid pacienteId);
    }
}