using Application.Validation.Nutricionistas;
using Application.ViewModel.Nutricionistas;
using Domain.Interface.Repository;

namespace Application.Commands.Nutricionistas
{
    public class NutricionistaAdicionarCommand : Command
    {
        public NutricionistaAdicionarViewModel nutricionistaViewModel { get; private set; }
        private readonly IUserRepository userRepository;

        public NutricionistaAdicionarCommand(
            NutricionistaAdicionarViewModel nutricionistaViewModel,
            IUserRepository userService)
        {
            this.nutricionistaViewModel = nutricionistaViewModel;
            this.userRepository = userService;
        }

        public override bool EhValido()
        {
            ValidationResult = new NutricionistaAdicionarValidation(userRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
