using Core.Interfaces.Services;
using Domain.Entity;
using Infrastructure.Data.Interfaces;

namespace Services
{
    public class PacienteService : ServiceBase<Paciente>, IPacienteService
    {
        private readonly IRepositoryBase<Paciente> repositoryPaciente;

        public PacienteService(IRepositoryBase<Paciente> repositoryPaciente)
            : base(repositoryPaciente)
        {
            this.repositoryPaciente = repositoryPaciente;
        }
    }
}