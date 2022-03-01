using Application.Commands;
using Application.Validation.Pacientes;
using Application.ViewModel.Pacientes;
using Core.Interfaces.Services;

namespace Application.Pacientes.Commands
{
    public class PacienteAtualizarCommand : Command
    {
        public PacienteViewModel pacienteViewModel { get; private set; }
        private readonly IUserService userService;

        public PacienteAtualizarCommand(
            PacienteViewModel pacienteViewModel,
            IUserService userService)
        {
            this.pacienteViewModel = pacienteViewModel;
            this.userService = userService;
        }

        public override bool EhValido()
        {
            ValidationResult = new PacienteAtualizarValidation(userService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
