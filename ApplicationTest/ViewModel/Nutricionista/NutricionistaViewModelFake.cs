using Application.ViewModel.Nutricionistas;
using DomainTest.Entity;
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

        public static NutricionistaViewModel GetFakeNull()
        {
            NutricionistaViewModel nutricionista = null;
            return nutricionista;
        }

        public static NutricionistaViewModel GetFakePacientesNull()
        {
            var nutricionista = GetFake();
            nutricionista.PacientesIds = null;
            return nutricionista;
        }

        public static NutricionistaViewModel GetFakeComPacientes()
        {
            var nutricionista = GetFake();
            nutricionista.PacientesIds = new List<Guid>()
            {
                PacienteEntityFake.Id
            };
            return nutricionista;
        }
    }
}
