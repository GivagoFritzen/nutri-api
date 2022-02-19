using Application.ViewModel.Nutricionistas;
using System;
using System.Collections.Generic;

namespace ApplicationTest.ViewModel.Nutricionista
{
    public static class NutricionistaAtualizarViewModelFake
    {
        public static NutricionistaAtualizarViewModel GetFake()
        {
            return new NutricionistaAtualizarViewModel()
            {
                NovaSenha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "email",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                PacientesIds = new List<Guid>()
            };
        }
    }
}
