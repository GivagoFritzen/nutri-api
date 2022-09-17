using Domain.Entity;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class MedidaRepository : IMedidaRepository
    {
        private IRepositorySQL<MedidaEntity> repositoryMedida { get; set; }

        public MedidaRepository(IRepositorySQL<MedidaEntity> repositoryMedida)
        {
            this.repositoryMedida = repositoryMedida;
        }

        public async Task AddAsync(MedidaEntity obj)
        {
            await repositoryMedida.AddAsync(obj);
        }

        public async Task<MedidaEntity> GetById(Guid id)
        {
            return await repositoryMedida.GetById(id);
        }

        public async Task<MedidaEntity> GetWithCircunferencia(Guid id)
        {
            return (await repositoryMedida.GetAllWithInclude("Circunferencia"))
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(MedidaEntity entity)
        {
            repositoryMedida.Update(entity);
        }
    }
}