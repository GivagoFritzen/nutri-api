using Application.Commands.Pacientes;
using ApplicationTest.ViewModel.Paciente;
using Domain.Interface.Repository;
using Moq;

namespace ApplicationTest.Command.Pacientes
{
    public static class PacientePlanoAlimentarCommandFake
    {
        private static Mock<IPacienteRepository> pacienteRepositoryMock = new Mock<IPacienteRepository>();

        public static PacientePlanoAlimentarCommand GetFake()
        {
            return new PacientePlanoAlimentarCommand(
                PacientePlanoAlimentarViewModelFake.GetFake(),
                pacienteRepositoryMock.Object);
        }

        public static PacientePlanoAlimentarCommand GetFakeRefeicaoNull()
        {
            return new PacientePlanoAlimentarCommand(
                PacientePlanoAlimentarViewModelFake.GetFakeRefeicaoNull(),
                pacienteRepositoryMock.Object);
        }

        public static PacientePlanoAlimentarCommand GetFakeRefeicaoEmpty()
        {
            return new PacientePlanoAlimentarCommand(
                PacientePlanoAlimentarViewModelFake.GetFakeRefeicaoEmpty(),
                pacienteRepositoryMock.Object);
        }
    }
}
