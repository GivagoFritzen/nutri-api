using Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IMedidaRepository
    {
        Task<MedidaEntity> GetById(Guid id);
        void Update(MedidaEntity entity);
    }
}