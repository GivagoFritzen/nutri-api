using Application.Validation.Nutricionistas;
using Application.ViewModel.Nutricionistas;
using Domain.Interface.Repository;

namespace Application.Commands.Nutricionistas
{
    public class NutricionistaDesvincularOuVincularCommand : Command
    {
        public NutricionistaDesvincularOuVincularViewModel nutricionistaViewModel { get; private set; }
        private readonly IUserRepository userRepository;

        public NutricionistaDesvincularOuVincularCommand(
            NutricionistaDesvincularOuVincularViewModel nutricionistaViewModel,
            IUserRepository userRepository)
        {
            this.nutricionistaViewModel = nutricionistaViewModel;
            this.userRepository = userRepository;
        }

        public override bool EhValido()
        {
            ValidationResult = new NutricionistaDesvincularOuVincularValidation(userRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
