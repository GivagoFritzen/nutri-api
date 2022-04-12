using Application.ViewModel.Nutricionistas;

namespace ApplicationTest.ViewModel.Nutricionista
{
    public static class NutricionistaAtualizarViewModelFake
    {
        public static NutricionistaAtualizarViewModel GetFake()
        {
            return new NutricionistaAtualizarViewModel()
            {
                AntigaSenha = "antiga",
                NovaSenha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAtualizarViewModel GetNomeVazioFake()
        {
            return new NutricionistaAtualizarViewModel()
            {
                AntigaSenha = "antiga",
                NovaSenha = "senha",
                Nome = "",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAtualizarViewModel GetSenhaAntigaInvalidaFake()
        {
            return new NutricionistaAtualizarViewModel()
            {
                AntigaSenha = "",
                NovaSenha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAtualizarViewModel GetSenhaNovaInvalidaFake()
        {
            return new NutricionistaAtualizarViewModel()
            {
                AntigaSenha = "senha",
                NovaSenha = "",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAtualizarViewModel GetEmailAbaixoDoPermitidoFake()
        {
            return new NutricionistaAtualizarViewModel()
            {
                AntigaSenha = "antiga",
                NovaSenha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "1",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAtualizarViewModel GetEmailAcimaDoPermitidoFake()
        {
            return new NutricionistaAtualizarViewModel()
            {
                AntigaSenha = "antiga",
                NovaSenha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = new string('t', 254) + "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAtualizarViewModel GetEmailRequisitosInvalidosFake()
        {
            return new NutricionistaAtualizarViewModel()
            {
                AntigaSenha = "antiga",
                NovaSenha = "senha",
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
