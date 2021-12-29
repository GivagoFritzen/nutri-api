using Application.ViewModel.Nutricionistas;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mapper
{
    public static class MapperNutricionista
    {
        public static NutricionistaEntity ToEntity(this NutricionistaAdicionarViewModel nutricionistaViewModel)
        {
            return nutricionistaViewModel == null ? null : new NutricionistaEntity()
            {
                Id = Guid.NewGuid(),
                Senha = nutricionistaViewModel.Senha,
                Nome = nutricionistaViewModel.Nome,
                Sobrenome = nutricionistaViewModel.Sobrenome,
                Email = nutricionistaViewModel.Email,
                Cidade = nutricionistaViewModel.Cidade,
                Telefone = nutricionistaViewModel.Telefone,
                Sexo = nutricionistaViewModel.Sexo,
                PacientesIds = nutricionistaViewModel.PacientesIds
            };
        }

        public static NutricionistaEntity ToEntity(this NutricionistaAtualizarViewModel nutricionistaViewModel)
        {
            return nutricionistaViewModel == null ? null : new NutricionistaEntity()
            {
                Id = nutricionistaViewModel.Id,
                Nome = nutricionistaViewModel.Nome,
                Senha = nutricionistaViewModel.NovaSenha,
                Sobrenome = nutricionistaViewModel.Sobrenome,
                Email = nutricionistaViewModel.Email,
                Cidade = nutricionistaViewModel.Cidade,
                Telefone = nutricionistaViewModel.Telefone,
                Sexo = nutricionistaViewModel.Sexo,
                PacientesIds = nutricionistaViewModel.PacientesIds
            };
        }

        public static NutricionistaViewModel ToViewModel(this NutricionistaEntity nutricionista)
        {
            return nutricionista == null ? null : new NutricionistaViewModel()
            {
                Nome = nutricionista.Nome,
                Sobrenome = nutricionista.Sobrenome,
                Email = nutricionista.Email,
                Cidade = nutricionista.Cidade,
                Telefone = nutricionista.Telefone,
                Sexo = nutricionista.Sexo,
                PacientesIds = nutricionista.PacientesIds
            };
        }

        public static IEnumerable<NutricionistaViewModel> ToViewModel(this IEnumerable<NutricionistaEntity> nutricionistas)
        {
            return nutricionistas.Select(nutricionista => new NutricionistaViewModel
            {
                Nome = nutricionista.Nome,
                Sobrenome = nutricionista.Sobrenome,
                Email = nutricionista.Email,
                Cidade = nutricionista.Cidade,
                Telefone = nutricionista.Telefone,
                Sexo = nutricionista.Sexo,
                PacientesIds = nutricionista.PacientesIds
            });
        }
    }
}
