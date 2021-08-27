using Application.Validation;
using Application.ViewModel;

namespace Application.Commands
{
    public class PacienteCommand : Command
    {
        public PacienteViewModel pacienteViewModel { get; private set; }

        public PacienteCommand(PacienteViewModel pacienteViewModel)
        {
            this.pacienteViewModel = pacienteViewModel;
        }

        public override bool EhValido()
        {
            ValidationResult = new PacienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
