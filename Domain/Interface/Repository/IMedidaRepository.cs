using Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IMedidaRepository
    {
        Task AddAsync(MedidaEntity obj);
        Task<MedidaEntity> GetById(Guid id);
        Task<MedidaEntity> GetWithCircunferencia(Guid id);
        void Update(MedidaEntity entity);
    }
}