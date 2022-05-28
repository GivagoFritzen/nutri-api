using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository.Base;

namespace Domain.Interface.Repository
{
    public interface IPacienteRepository : IRepositoryBase<PacienteEntity, PacienteEvent>
    {
    }
}