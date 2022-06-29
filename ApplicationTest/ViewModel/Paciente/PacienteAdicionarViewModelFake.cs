using Application.ViewModel.Pacientes;

namespace ApplicationTest.ViewModel.Paciente
{
    public static class PacienteAdicionarViewModelFake
    {
        public static PacienteAdicionarViewModel GetFake()
        {
            return new PacienteAdicionarViewModel()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static PacienteAdicionarViewModel GetNomeVazioFake()
        {
            return new PacienteAdicionarViewModel()
            {
                Nome = "",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static PacienteAdicionarViewModel GetEmailAbaixoDoPermitidoFake()
        {
            return new PacienteAdicionarViewModel()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "1",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static PacienteAdicionarViewModel GetEmailAcimaDoPermitidoFake()
        {
            return new PacienteAdicionarViewModel()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = new string('t', 254) + "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static PacienteAdicionarViewModel GetEmailRequisitosInvalidosFake()
        {
            return new PacienteAdicionarViewModel()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }
    }
}
