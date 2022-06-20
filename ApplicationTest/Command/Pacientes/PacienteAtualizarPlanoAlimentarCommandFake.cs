using Application.Commands.Pacientes;
using ApplicationTest.ViewModel.Paciente;
using Domain.Interface.Repository;
using Moq;

namespace ApplicationTest.Command.Pacientes
{
    public static class PacienteAtualizarPlanoAlimentarCommandFake
    {
        public static PacienteAtualizarPlanoAlimentarCommand GetFake()
        {
            var planoAlimentarRepositoryMock = new Mock<IPlanoAlimentarRepository>();

            return new PacienteAtualizarPlanoAlimentarCommand(
                PacienteAtualizarPlanoAlimentarViewModelFake.GetFake(),
                planoAlimentarRepositoryMock.Object);
        }
    }
}
