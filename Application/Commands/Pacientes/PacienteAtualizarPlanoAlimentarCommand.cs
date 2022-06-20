using Application.Validation.Pacientes;
using Application.ViewModel.Pacientes;
using Domain.Interface.Repository;

namespace Application.Commands.Pacientes
{
    public class PacienteAtualizarPlanoAlimentarCommand : Command
    {
        public PacienteAtualizarPlanoAlimentarViewModel pacienteAtualizarPlanoAlimentarViewModel { get; private set; }
        public IPlanoAlimentarRepository planoAlimentarRepository { get; private set; }

        public PacienteAtualizarPlanoAlimentarCommand(
            PacienteAtualizarPlanoAlimentarViewModel pacienteAtualizarPlanoAlimentarViewModel,
            IPlanoAlimentarRepository planoAlimentarRepository)
        {
            this.pacienteAtualizarPlanoAlimentarViewModel = pacienteAtualizarPlanoAlimentarViewModel;
            this.planoAlimentarRepository = planoAlimentarRepository;
        }

        public override bool EhValido()
        {
            ValidationResult = new PacienteAtualizarPlanoAlimentarValidation(planoAlimentarRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
