using Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IPlanoAlimentarRepository
    {
        Task AddAsync(PlanoAlimentarEntity planoAlimentar);
        Task<PlanoAlimentarEntity> GetById(Guid id);
        void Update(PlanoAlimentarEntity entity);
    }
}