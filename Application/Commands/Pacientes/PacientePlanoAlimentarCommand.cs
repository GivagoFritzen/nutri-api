using Application.Validation.Pacientes;
using Application.ViewModel.Pacientes;
using Domain.Interface.Repository;

namespace Application.Commands.Pacientes
{
    public class PacientePlanoAlimentarCommand : Command
    {
        public PacientePlanoAlimentarViewModel pacienteViewModel { get; private set; }
        private readonly IPacienteRepository pacienteRepository;

        public PacientePlanoAlimentarCommand(
            PacientePlanoAlimentarViewModel pacienteViewModel,
            IPacienteRepository pacienteRepository)
        {
            this.pacienteViewModel = pacienteViewModel;
            this.pacienteRepository = pacienteRepository;
        }

        public override bool EhValido()
        {
            ValidationResult = new PacientePlanoAlimentarValidation(pacienteRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
