using Application.Commands.Pacientes;
using ApplicationTest.ViewModel.Paciente;
using Domain.Interface.Repository;
using Moq;

namespace ApplicationTest.Command.Pacientes
{
    public static class PacienteAtualizarCommandFake
    {
        private static Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

        public static PacienteAtualizarCommand GetFake()
        {
            return new PacienteAtualizarCommand(
                PacienteAtualizarViewModelFake.GetFake(),
                userRepositoryMock.Object);
        }

        public static PacienteAtualizarCommand GetNomeVazioFake()
        {
            return new PacienteAtualizarCommand(
                PacienteAtualizarViewModelFake.GetNomeVazioFake(),
                userRepositoryMock.Object);
        }

        public static PacienteAtualizarCommand GetEmailAbaixoDoPermitidoFake()
        {
            return new PacienteAtualizarCommand(
                PacienteAtualizarViewModelFake.GetEmailAbaixoDoPermitidoFake(),
                userRepositoryMock.Object);
        }

        public static PacienteAtualizarCommand GetEmailAcimaDoPermitidoFake()
        {
            return new PacienteAtualizarCommand(
                PacienteAtualizarViewModelFake.GetEmailAcimaDoPermitidoFake(),
                userRepositoryMock.Object);
        }

        public static PacienteAtualizarCommand GetEmailRequisitosInvalidosFake()
        {
            return new PacienteAtualizarCommand(
                PacienteAtualizarViewModelFake.GetEmailRequisitosInvalidosFake(),
                userRepositoryMock.Object);
        }
    }
}
