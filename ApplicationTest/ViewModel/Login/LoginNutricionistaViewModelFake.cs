using Application.ViewModel.Login;

namespace ApplicationTest.ViewModel.Login
{
    public static class LoginNutricionistaViewModelFake
    {
        public static LoginNutricionistaViewModel GetFake()
        {
            return new LoginNutricionistaViewModel()
            {
                Senha = "senha",
                Email = "teste@provedor.com"
            };
        }

        public static LoginNutricionistaViewModel GetSenhaInvalido()
        {
            return new LoginNutricionistaViewModel()
            {
                Email = "teste@provedor.com"
            };
        }

        public static LoginNutricionistaViewModel GetEmailAbaixoDoPermitidoFake()
        {
            return new LoginNutricionistaViewModel()
            {
                Senha = "senha",
                Email = "1"
            };
        }

        public static LoginNutricionistaViewModel GetEmailAcimaDoPermitidoFake()
        {
            return new LoginNutricionistaViewModel()
            {
                Senha = "senha",
                Email = new string('t', 254) + "teste@provedor.com"
            };
        }

        public static LoginNutricionistaViewModel GetEmailRequisitosInvalidosFake()
        {
            return new LoginNutricionistaViewModel()
            {
                Senha = "senha",
                Email = "teste"
            };
        }
    }
}
