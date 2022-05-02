using Application.Commands.Nutricionistas;
using ApplicationTest.ViewModel.Nutricionista;
using Core.Interfaces.Services;
using Moq;

namespace ApplicationTest.Command.Nutricionistas
{
    public static class NutricionistaAtualizarCommandFake
    {
        private static Mock<ISecurityService> securityServiceMock = new Mock<ISecurityService>();
        private static Mock<IUserService> userServiceMock = new Mock<IUserService>();

        public static NutricionistaAtualizarCommand GetFake()
        {
            return new NutricionistaAtualizarCommand(
                securityServiceMock.Object,
                NutricionistaAtualizarViewModelFake.GetFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAtualizarCommand GetNomeVazioFake()
        {
            return new NutricionistaAtualizarCommand(
                securityServiceMock.Object,
                NutricionistaAtualizarViewModelFake.GetNomeVazioFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAtualizarCommand GetSenhaAntigaInvalidaFake()
        {
            return new NutricionistaAtualizarCommand(
                securityServiceMock.Object,
                NutricionistaAtualizarViewModelFake.GetSenhaAntigaInvalidaFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAtualizarCommand GetSenhaNovaInvalidaFake()
        {
            return new NutricionistaAtualizarCommand(
                securityServiceMock.Object,
                NutricionistaAtualizarViewModelFake.GetSenhaNovaInvalidaFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAtualizarCommand GetEmailAbaixoDoPermitidoFake()
        {
            return new NutricionistaAtualizarCommand(
                securityServiceMock.Object,
                NutricionistaAtualizarViewModelFake.GetEmailAbaixoDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAtualizarCommand GetEmailAcimaDoPermitidoFake()
        {
            return new NutricionistaAtualizarCommand(
                securityServiceMock.Object,
                NutricionistaAtualizarViewModelFake.GetEmailAcimaDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static NutricionistaAtualizarCommand GetEmailRequisitosInvalidosFake()
        {
            return new NutricionistaAtualizarCommand(
                securityServiceMock.Object,
                NutricionistaAtualizarViewModelFake.GetEmailRequisitosInvalidosFake(),
                userServiceMock.Object);
        }
    }
}
