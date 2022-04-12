using Domain.Entity;
using Domain.Event;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPacienteService : IServiceBase<PacienteEntity, PacienteEvent>
    {
        Task<IEnumerable<PacienteEntity>> GetAllByListIdAsync(List<Guid> pacientesId);
    }
}