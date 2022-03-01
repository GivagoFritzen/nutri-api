using Application.Commands.Admin;
using ApplicationTest.ViewModel.Admin;
using Core.Interfaces.Services;
using Moq;

namespace ApplicationTest.Command.Admin
{
    public static class AdminAdicionarCommandFake
    {
        private static Mock<IUserService> userServiceMock = new Mock<IUserService>();

        public static AdminAdicionarCommand GetFake()
        {
            return new AdminAdicionarCommand(
                AdminViewModelFake.GetFake(),
                userServiceMock.Object);
        }

        public static AdminAdicionarCommand GetSenhaInvalidaFake()
        {
            return new AdminAdicionarCommand(
                AdminViewModelFake.GetSenhaInvalidaFake(),
                userServiceMock.Object);
        }

        public static AdminAdicionarCommand GetEmailAbaixoDoPermitidoFake()
        {
            return new AdminAdicionarCommand(
                AdminViewModelFake.GetEmailAbaixoDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static AdminAdicionarCommand GetEmailAcimaDoPermitidoFake()
        {
            return new AdminAdicionarCommand(
                AdminViewModelFake.GetEmailAcimaDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static AdminAdicionarCommand GetEmailRequisitosInvalidosFake()
        {
            return new AdminAdicionarCommand(
                AdminViewModelFake.GetEmailRequisitosInvalidosFake(),
                userServiceMock.Object);
        }
    }
}
