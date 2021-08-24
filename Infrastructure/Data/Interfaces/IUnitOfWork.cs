using Domain.Entity;

namespace Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryBase<Paciente> Pacientes { get; }

        public void Commit();
        public void RollBack();
    }
}
