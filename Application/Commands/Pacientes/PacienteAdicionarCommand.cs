using Application.Commands;
using Application.Validation.Pacientes;
using Application.ViewModel.Pacientes;
using Domain.Interface.Repository;

namespace Application.Pacientes.Commands
{
    public class PacienteAdicionarCommand : Command
    {
        public PacienteAdicionarViewModel pacienteViewModel { get; private set; }
        private readonly IUserRepository userRepository;

        public PacienteAdicionarCommand(
            PacienteAdicionarViewModel pacienteViewModel,
            IUserRepository userRepository)
        {
            this.pacienteViewModel = pacienteViewModel;
            this.userRepository = userRepository;
        }

        public override bool EhValido()
        {
            ValidationResult = new PacienteAdicionarValidation(userRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
