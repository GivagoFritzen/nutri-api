using Application.ViewModel.Pacientes;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mapper
{
    public static class MapperRefeicao
    {
        public static List<RefeicaoEntity> ToEntity(this IEnumerable<RefeicaoViewModel> refeicoesViewModel)
        {
            return refeicoesViewModel == null ? null : refeicoesViewModel.Select(refeicaoViewModel => new RefeicaoEntity()
            {
                Horario = refeicaoViewModel.Horario,
                Descricao = refeicaoViewModel.Descricao,
                Alimentos = refeicaoViewModel.Alimentos.ToEntity()
            }).ToList();
        }

        public static List<RefeicaoViewModel> ToViewModel(this IEnumerable<RefeicaoEntity> entity)
        {
            return entity == null ? null : entity.Select(refeicao => new RefeicaoViewModel()
            {
                Horario = refeicao.Horario,
                Descricao = refeicao.Descricao,
                Alimentos = refeicao.Alimentos.ToViewModel()
            }).ToList();
        }
    }
}
