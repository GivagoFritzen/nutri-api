using Application.ViewModel.Medidas;
using Application.ViewModel.Pacientes;
using System;
using System.Collections.Generic;

namespace ApplicationTest.ViewModel.Paciente
{
    public static class PacienteViewModelFake
    {
        public static PacienteViewModel GetFake()
        {
            return new PacienteViewModel()
            {
                Id = Guid.NewGuid(),
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medidas = new List<MedidaViewModel>(),
            };
        }

        public static PacienteViewModel GetDifferentIdFake(Guid id)
        {
            return new PacienteViewModel()
            {
                Id = id,
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medidas = new List<MedidaViewModel>(),
            };
        }

        public static List<PacienteViewModel> GetListDifferentIdFake(Guid id)
        {
            return new List<PacienteViewModel>() {
                new PacienteViewModel()
                {
                    Id = id,
                    Nome = "nome",
                    Sobrenome = "sobrenome",
                    Email = "teste@provedor.com",
                    Cidade = "cidade",
                    Telefone = "99999999",
                    Sexo = true,
                    Medidas = new List<MedidaViewModel>()
                }
            };
        }

        public static PacienteViewModel GetNomeVazioFake()
        {
            return new PacienteViewModel()
            {
                Nome = "",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medidas = new List<MedidaViewModel>(),
            };
        }
    }
}
