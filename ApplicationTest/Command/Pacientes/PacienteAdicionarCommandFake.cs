using Application.Pacientes.Commands;
using ApplicationTest.ViewModel.Paciente;
using Core.Interfaces.Services;
using Moq;

namespace ApplicationTest.Command.Pacientes
{
    public static class PacienteAdicionarCommandFake
    {
        private static Mock<IUserService> userServiceMock = new Mock<IUserService>();

        public static PacienteAdicionarCommand GetFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetFake(),
                userServiceMock.Object);
        }

        public static PacienteAdicionarCommand GetNomeVazioFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetNomeVazioFake(),
                userServiceMock.Object);
        }

        public static PacienteAdicionarCommand GetEmailAbaixoDoPermitidoFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetEmailAbaixoDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static PacienteAdicionarCommand GetEmailAcimaDoPermitidoFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetEmailAcimaDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static PacienteAdicionarCommand GetEmailRequisitosInvalidosFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetEmailRequisitosInvalidosFake(),
                userServiceMock.Object);
        }
    }
}
