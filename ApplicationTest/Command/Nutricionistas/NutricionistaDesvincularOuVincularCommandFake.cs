using Application.Commands.Nutricionistas;
using ApplicationTest.ViewModel.Nutricionista;
using Core.Interfaces.Services;
using Moq;

namespace ApplicationTest.Command.Nutricionistas
{
    public static class NutricionistaDesvincularOuVincularCommandFake
    {
        private static Mock<IUserService> userServiceMock = new Mock<IUserService>();

        public static NutricionistaDesvincularOuVincularCommand GetFake()
        {
            return new NutricionistaDesvincularOuVincularCommand(
                NutricionistaDesvincularOuVincularViewModelFake.GetFake(),
                userServiceMock.Object);
        }

        public static NutricionistaDesvincularOuVincularCommand GetFakeIdVazio()
        {
            return new NutricionistaDesvincularOuVincularCommand(
                NutricionistaDesvincularOuVincularViewModelFake.GetFakeIdVazio(),
                userServiceMock.Object);
        }
    }
}
