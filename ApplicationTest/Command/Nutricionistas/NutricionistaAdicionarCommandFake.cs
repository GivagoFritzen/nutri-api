using Application.Commands.Nutricionistas;
using ApplicationTest.ViewModel.Nutricionista;
using Domain.Interface.Repository;
using Moq;

namespace ApplicationTest.Command.Nutricionistas
{
    public static class NutricionistaAdicionarCommandFake
    {
        private static Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

        public static NutricionistaAdicionarCommand GetFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetFake(),
                userRepositoryMock.Object);
        }

        public static NutricionistaAdicionarCommand GetNomeVazioFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetNomeVazioFake(),
                userRepositoryMock.Object);
        }

        public static NutricionistaAdicionarCommand GetSenhaInvalidaFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetSenhaInvalidaFake(),
                userRepositoryMock.Object);
        }

        public static NutricionistaAdicionarCommand GetEmailAbaixoDoPermitidoFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetEmailAbaixoDoPermitidoFake(),
                userRepositoryMock.Object);
        }

        public static NutricionistaAdicionarCommand GetEmailAcimaDoPermitidoFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetEmailAcimaDoPermitidoFake(),
                userRepositoryMock.Object);
        }

        public static NutricionistaAdicionarCommand GetEmailRequisitosInvalidosFake()
        {
            return new NutricionistaAdicionarCommand(
                NutricionistaAdicionarViewModelFake.GetEmailRequisitosInvalidosFake(),
                userRepositoryMock.Object);
        }
    }
}
