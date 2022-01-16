using Application.Commands;
using Application.Validation.Pacientes;
using Application.ViewModel.Pacientes;
using Core.Interfaces.Services;

namespace Application.Pacientes.Commands
{
    public class AdicionarPacienteCommand : Command
    {
        public PacienteAdicionarViewModel pacienteViewModel { get; private set; }
        private readonly IPacienteService pacienteService;

        public AdicionarPacienteCommand(
            PacienteAdicionarViewModel pacienteViewModel,
            IPacienteService pacienteService)
        {
            this.pacienteViewModel = pacienteViewModel;
            this.pacienteService = pacienteService;
        }

        public override bool EhValido()
        {
            ValidationResult = new PacienteValidation(pacienteService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
