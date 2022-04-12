using Application.ViewModel.Pacientes;
using System;

namespace ApplicationTest.ViewModel.Paciente
{
    public static class PacienteAtualizarViewModelFake
    {
        public static PacienteAtualizarViewModel GetFake()
        {
            return new PacienteAtualizarViewModel()
            {
                Id = Guid.NewGuid(),
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medida = null,
            };
        }

        public static PacienteAtualizarViewModel GetNomeVazioFake()
        {
            return new PacienteAtualizarViewModel()
            {
                Nome = "",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medida = null,
            };
        }

        public static PacienteAtualizarViewModel GetEmailAbaixoDoPermitidoFake()
        {
            return new PacienteAtualizarViewModel()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "1",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medida = null,
            };
        }

        public static PacienteAtualizarViewModel GetEmailAcimaDoPermitidoFake()
        {
            return new PacienteAtualizarViewModel()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = new string('t', 254) + "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medida = null,
            };
        }

        public static PacienteAtualizarViewModel GetEmailRequisitosInvalidosFake()
        {
            return new PacienteAtualizarViewModel()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medida = null,
            };
        }
    }
}
