using Core.Interfaces.Services;
using Domain.Entity;
using Infrastructure.Data.Interfaces;
using Services.Base;

namespace Services
{
    public class PacienteService : ServiceBase<PacienteEntity>, IPacienteService
    {
        public PacienteService(IRepositoryBase<PacienteEntity> repositoryPaciente)
            : base(repositoryPaciente)
        {
            repository = repositoryPaciente;
        }
    }
}