using Application.ViewModel.Admin;

namespace ApplicationTest.ViewModel.Admin
{
    public static class AdminViewModelFake
    {
        public static AdminAdicionarViewModel GetFake(
            string senha = "senha",
            string email = "teste@provedor.com")
        {
            return new AdminAdicionarViewModel()
            {
                Senha = senha,
                Email = email
            };
        }

        public static AdminAdicionarViewModel GetSenhaInvalidaFake()
        {
            return new AdminAdicionarViewModel()
            {
                Senha = "",
                Email = "teste@provedor.com"
            };
        }

        public static AdminAdicionarViewModel GetEmailAbaixoDoPermitidoFake()
        {
            return new AdminAdicionarViewModel()
            {
                Senha = "senha",
                Email = "1"
            };
        }

        public static AdminAdicionarViewModel GetEmailAcimaDoPermitidoFake()
        {
            return new AdminAdicionarViewModel()
            {
                Senha = "senha",
                Email = new string('t', 254) + "teste@provedor.com"
            };
        }

        public static AdminAdicionarViewModel GetEmailRequisitosInvalidosFake()
        {
            return new AdminAdicionarViewModel()
            {
                Senha = "senha",
                Email = "teste"
            };
        }
    }
}
