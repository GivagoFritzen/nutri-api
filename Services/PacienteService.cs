using Core.Interfaces.Services;
using Domain.Entity;
using Infrastructure.Data.Interfaces;

namespace Services
{
    public class PacienteService : ServiceBase<Paciente>, IPacienteService
    {
        public PacienteService(IRepositoryBase<Paciente> repositoryPaciente)
            : base(repositoryPaciente)
        {
            repository = repositoryPaciente;
        }
    }
}