using Application.ViewModel.Nutricionistas;
using System;
using System.Collections.Generic;

namespace ApplicationTest.ViewModel.Nutricionista
{
    public static class NutricionistaViewModelFake
    {
        public static NutricionistaViewModel GetFake()
        {
            return new NutricionistaViewModel()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                PacientesIds = new List<Guid>()
            };
        }

        public static List<NutricionistaViewModel> GetListFake()
        {
            return new List<NutricionistaViewModel>()
            {
                GetFake()
            };
        }
    }
}
