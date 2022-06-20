using Application.ViewModel.Pacientes;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mapper
{
    public static class MapperPlanoAlimentar
    {
        public static PlanoAlimentarEntity ToEntity(this PlanoAlimentarViewModel planoAlimentarViewModel)
        {
            return planoAlimentarViewModel == null ? null : new PlanoAlimentarEntity
            {
                Data = planoAlimentarViewModel.Data,
                Refeicoes = planoAlimentarViewModel.Refeicoes.ToEntity()
            };
        }

        public static IEnumerable<PlanoAlimentarViewModel> ToListPlanoAlimentarViewModel(this IEnumerable<PlanoAlimentarEntity> planosAlimentares)
        {
            return planosAlimentares == null ? null :
                planosAlimentares.Select(planoAlimentar =>
                new PlanoAlimentarViewModel
                {
                    Data = planoAlimentar.Data,
                    Refeicoes = planoAlimentar.Refeicoes.ToViewModel()
                });
        }
    }
}
