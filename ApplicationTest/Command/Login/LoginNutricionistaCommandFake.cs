using Application.Commands.Login;
using ApplicationTest.ViewModel.Login;

namespace ApplicationTest.Command.Login
{
    public static class LoginNutricionistaCommandFake
    {
        public static LoginNutricionistaCommand GetFake()
        {
            return new LoginNutricionistaCommand(LoginNutricionistaViewModelFake.GetFake());
        }

        public static LoginNutricionistaCommand GetSenhaInvalido()
        {
            return new LoginNutricionistaCommand(LoginNutricionistaViewModelFake.GetSenhaInvalido());
        }

        public static LoginNutricionistaCommand GetEmailAbaixoDoPermitidoFake()
        {
            return new LoginNutricionistaCommand(LoginNutricionistaViewModelFake.GetEmailAbaixoDoPermitidoFake());
        }

        public static LoginNutricionistaCommand GetEmailAcimaDoPermitidoFake()
        {
            return new LoginNutricionistaCommand(LoginNutricionistaViewModelFake.GetEmailAcimaDoPermitidoFake());
        }

        public static LoginNutricionistaCommand GetEmailRequisitosInvalidosFake()
        {
            return new LoginNutricionistaCommand(LoginNutricionistaViewModelFake.GetEmailRequisitosInvalidosFake());
        }
    }
}
