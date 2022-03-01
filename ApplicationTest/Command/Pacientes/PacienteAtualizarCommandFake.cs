using Application.Pacientes.Commands;
using ApplicationTest.ViewModel.Paciente;
using Core.Interfaces.Services;
using Moq;

namespace ApplicationTest.Command.Pacientes
{
    public static class PacienteAtualizarCommandFake
    {
        private static Mock<IUserService> userServiceMock = new Mock<IUserService>();

        public static PacienteAtualizarCommand GetFake()
        {
            return new PacienteAtualizarCommand(
                PacienteViewModelFake.GetFake(),
                userServiceMock.Object);
        }

        public static PacienteAtualizarCommand GetNomeVazioFake()
        {
            return new PacienteAtualizarCommand(
                PacienteViewModelFake.GetNomeVazioFake(),
                userServiceMock.Object);
        }

        public static PacienteAtualizarCommand GetEmailAbaixoDoPermitidoFake()
        {
            return new PacienteAtualizarCommand(
                PacienteViewModelFake.GetEmailAbaixoDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static PacienteAtualizarCommand GetEmailAcimaDoPermitidoFake()
        {
            return new PacienteAtualizarCommand(
                PacienteViewModelFake.GetEmailAcimaDoPermitidoFake(),
                userServiceMock.Object);
        }

        public static PacienteAtualizarCommand GetEmailRequisitosInvalidosFake()
        {
            return new PacienteAtualizarCommand(
                PacienteViewModelFake.GetEmailRequisitosInvalidosFake(),
                userServiceMock.Object);
        }
    }
}
