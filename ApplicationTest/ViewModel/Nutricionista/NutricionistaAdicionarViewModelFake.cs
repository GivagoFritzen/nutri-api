using Application.ViewModel.Nutricionistas;

namespace ApplicationTest.ViewModel.Nutricionista
{
    public static class NutricionistaAdicionarViewModelFake
    {
        public static NutricionistaAdicionarViewModel GetFake()
        {
            return new NutricionistaAdicionarViewModel()
            {
                Senha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAdicionarViewModel GetNomeVazioFake()
        {
            return new NutricionistaAdicionarViewModel()
            {
                Senha = "senha",
                Nome = "",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAdicionarViewModel GetSenhaInvalidaFake()
        {
            return new NutricionistaAdicionarViewModel()
            {
                Senha = "",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAdicionarViewModel GetEmailAbaixoDoPermitidoFake()
        {
            return new NutricionistaAdicionarViewModel()
            {
                Senha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "1",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAdicionarViewModel GetEmailAcimaDoPermitidoFake()
        {
            return new NutricionistaAdicionarViewModel()
            {
                Senha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = new string('t', 254) + "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true
            };
        }

        public static NutricionistaAdicionarViewModel GetEmailRequisitosInvalidosFake()
        {
            return new NutricionistaAdicionarViewModel()
            {
                Senha = "senha",
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
