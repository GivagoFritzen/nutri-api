using Application.Commands.Pacientes;
using ApplicationTest.ViewModel.Paciente;
using Domain.Interface.Repository;
using Moq;

namespace ApplicationTest.Command.Pacientes
{
    public static class PacienteAdicionarCommandFake
    {
        private static Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

        public static PacienteAdicionarCommand GetFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetFake(),
                userRepositoryMock.Object);
        }

        public static PacienteAdicionarCommand GetNomeVazioFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetNomeVazioFake(),
                userRepositoryMock.Object);
        }

        public static PacienteAdicionarCommand GetEmailAbaixoDoPermitidoFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetEmailAbaixoDoPermitidoFake(),
                userRepositoryMock.Object);
        }

        public static PacienteAdicionarCommand GetEmailAcimaDoPermitidoFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetEmailAcimaDoPermitidoFake(),
                userRepositoryMock.Object);
        }

        public static PacienteAdicionarCommand GetEmailRequisitosInvalidosFake()
        {
            return new PacienteAdicionarCommand(
                PacienteAdicionarViewModelFake.GetEmailRequisitosInvalidosFake(),
                userRepositoryMock.Object);
        }
    }
}
