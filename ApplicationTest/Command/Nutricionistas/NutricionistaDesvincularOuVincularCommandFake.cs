using Application.Commands.Nutricionistas;
using ApplicationTest.ViewModel.Nutricionista;
using Domain.Interface.Repository;
using Moq;

namespace ApplicationTest.Command.Nutricionistas
{
    public static class NutricionistaDesvincularOuVincularCommandFake
    {
        private static Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

        public static NutricionistaDesvincularOuVincularCommand GetFake()
        {
            return new NutricionistaDesvincularOuVincularCommand(
                NutricionistaDesvincularOuVincularViewModelFake.GetFake(),
                userRepositoryMock.Object);
        }

        public static NutricionistaDesvincularOuVincularCommand GetFakeIdVazio()
        {
            return new NutricionistaDesvincularOuVincularCommand(
                NutricionistaDesvincularOuVincularViewModelFake.GetFakeIdVazio(),
                userRepositoryMock.Object);
        }
    }
}
