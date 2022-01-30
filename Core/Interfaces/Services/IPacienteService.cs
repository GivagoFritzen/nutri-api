using Domain.Entity;
using Domain.Event;
using System;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPacienteService : IServiceBase<PacienteEntity, PacienteEvent>
    {
        Task<bool> VerificarEmailExiste(string email);
        Task<bool> VerificarEmailExiste(string email, Guid currentId);
    }
}