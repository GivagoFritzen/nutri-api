﻿using Application.ViewModel.Pacientes;
using Application.ViewModel.PlanosAlimentares;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mapper
{
    public static class MapperPlanoAlimentar
    {
        public static PlanoAlimentarEntity ToEntity(this PacienteAtualizarPlanoAlimentarViewModel viewModel)
        {
            return viewModel == null ? null : new PlanoAlimentarEntity
            {
                Data = viewModel.PlanoAlimentar.Data,
                Refeicoes = viewModel.PlanoAlimentar.Refeicoes.ToEntity()
            };
        }

        public static IEnumerable<PlanoAlimentarViewModel> ToListPlanoAlimentarViewModel(this IEnumerable<PlanoAlimentarEntity> planosAlimentares)
        {
            return planosAlimentares == null ? null :
                planosAlimentares.Select(planoAlimentar =>
                new PlanoAlimentarViewModel
                {
                    Id = planoAlimentar.Id,
                    Data = planoAlimentar.Data,
                    Refeicoes = planoAlimentar.Refeicoes.ToViewModel()
                });
        }
    }
}
