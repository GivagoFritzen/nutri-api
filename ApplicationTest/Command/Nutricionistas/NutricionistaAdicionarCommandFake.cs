using Application.Commands.Nutricionistas;
using ApplicationTest.ViewModel.Nutricionista;
using Core.Interfaces.Services;
using Moq;

namespace ApplicationTest.Command.Nutricionistas
{
    public static class NutricionistaAdicionarCommandFake
    {
        private static Mock<IUserService> userServiceMock = new Mock<IUserService>();

        public static NutricionistaAdicionarCommand GetFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAdicionarCommand GetNomeVazioFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetNomeVazioFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAdicionarCommand GetSenhaInvalidaFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetSenhaInvalidaFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAdicionarCommand GetEmailAbaixoDoPermitidoFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetEmailAbaixoDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAdicionarCommand GetEmailAcimaDoPermitidoFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetEmailAcimaDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAdicionarCommand GetEmailRequisitosInvalidosFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetEmailRequisitosInvalidosFake(),
                userServiceMock.Object);
        }
    }
}
