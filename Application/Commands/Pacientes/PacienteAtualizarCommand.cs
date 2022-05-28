using Application.Commands;
using Application.Validation.Pacientes;
using Application.ViewModel.Pacientes;
using Domain.Interface.Repository;

namespace Application.Pacientes.Commands
{
    public class PacienteAtualizarCommand : Command
    {
        public PacienteAtualizarViewModel pacienteViewModel { get; private set; }
        private readonly IUserRepository userRepository;

        public PacienteAtualizarCommand(
            PacienteAtualizarViewModel pacienteViewModel,
            IUserRepository userRepository)
        {
            this.pacienteViewModel = pacienteViewModel;
            this.userRepository = userRepository;
        }

        public override bool EhValido()
        {
            ValidationResult = new PacienteAtualizarValidation(userRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
