using Application.Commands;
using Application.Validation;
using Application.ViewModel;

namespace Application.Pacientes.Commands
{
    public class AdicionarPacienteCommand : Command
    {
        public PacienteViewModel pacienteViewModel { get; private set; }

        public AdicionarPacienteCommand(PacienteViewModel pacienteViewModel)
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
