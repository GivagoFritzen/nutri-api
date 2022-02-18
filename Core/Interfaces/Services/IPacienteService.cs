using Domain.Entity;
using Domain.Event;

namespace Core.Interfaces.Services
{
    public interface IPacienteService : IServiceBase<PacienteEntity, PacienteEvent>
    {
    }
}