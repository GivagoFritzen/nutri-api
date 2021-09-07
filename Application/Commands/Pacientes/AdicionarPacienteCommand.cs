using Application.Commands;
using Application.Validation;
using Application.ViewModel.Pacientes;

namespace Application.Pacientes.Commands
{
    public class AdicionarPacienteCommand : Command
    {
        public PacienteAdicionarViewModel pacienteViewModel { get; private set; }

        public AdicionarPacienteCommand(PacienteAdicionarViewModel pacienteViewModel)
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
