using Application.Commands;
using Application.Validation.Pacientes;
using Application.ViewModel.Pacientes;
using Core.Interfaces.Services;

namespace Application.Pacientes.Commands
{
    public class PacienteAdicionarCommand : Command
    {
        public PacienteAdicionarViewModel pacienteViewModel { get; private set; }
        private readonly IUserService userService;

        public PacienteAdicionarCommand(
            PacienteAdicionarViewModel pacienteViewModel,
            IUserService userService)
        {
            this.pacienteViewModel = pacienteViewModel;
            this.userService = userService;
        }

        public override bool EhValido()
        {
            ValidationResult = new PacienteAdicionarValidation(userService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
