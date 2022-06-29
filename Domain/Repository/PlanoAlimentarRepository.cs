using Domain.Entity;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Base;
using System;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class PlanoAlimentarRepository : IPlanoAlimentarRepository
    {
        private IRepositorySQL<PlanoAlimentarEntity> repositoryPlanoAlimentar { get; set; }

        public PlanoAlimentarRepository(IRepositorySQL<PlanoAlimentarEntity> repositoryPlanoAlimentar)
        {
            this.repositoryPlanoAlimentar = repositoryPlanoAlimentar;
        }

        public async Task AddAsync(PlanoAlimentarEntity planoAlimentar)
        {
            await repositoryPlanoAlimentar.AddAsync(planoAlimentar);
        }

        public async Task<PlanoAlimentarEntity> GetById(Guid id)
        {
            return await repositoryPlanoAlimentar.GetById(id);
        }

        public void Update(PlanoAlimentarEntity entity)
        {
            repositoryPlanoAlimentar.Update(entity);
        }
    }
}