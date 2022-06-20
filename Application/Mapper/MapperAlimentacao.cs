using Application.ViewModel.Pacientes;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mapper
{
    public static class MapperAlimentacao
    {
        public static List<AlimentoEntity> ToEntity(this List<AlimentoViewModel> alimentoViewModel)
        {
            return alimentoViewModel == null ? null : alimentoViewModel.Select(alimento => new AlimentoEntity()
            {
                Nome = alimento.Nome,
                Medida = alimento.Medida,
                Quantidade = alimento.Quantidade
            }).ToList();
        }

        public static List<AlimentoViewModel> ToViewModel(this List<AlimentoEntity> alimentoEntity)
        {
            return alimentoEntity == null ? null : alimentoEntity.Select(alimento => new AlimentoViewModel()
            {
                Nome = alimento.Nome,
                Medida = alimento.Medida,
                Quantidade = alimento.Quantidade
            }).ToList();
        }
    }
}
