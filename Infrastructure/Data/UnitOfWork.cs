using Domain.Entity;
using Infrastructure.Data.Interfaces;
using System;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public readonly DataContext context;
        private IRepositoryBase<Paciente> pacientesRepository { get; }

        public UnitOfWork(DataContext context, IRepositoryBase<Paciente> pacientesRepository)
        {
            this.context = context;
            this.pacientesRepository = pacientesRepository;
        }

        public IRepositoryBase<Paciente> Pacientes => throw new NotImplementedException();

        public void Commit()
        {
            context.SaveChanges();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
                context.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}