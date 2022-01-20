using Application.Validation.Nutricionistas;
using Application.ViewModel.Nutricionistas;
using Services;

namespace Application.Commands.Nutricionistas
{
    public class NutricionistaAdicionarCommand : Command
    {
        public NutricionistaAdicionarViewModel nutricionistaViewModel { get; private set; }
        private readonly IUserService userService;

        public NutricionistaAdicionarCommand(
            NutricionistaAdicionarViewModel nutricionistaViewModel,
            IUserService userService)
        {
            this.nutricionistaViewModel = nutricionistaViewModel;
            this.userService = userService;
        }

        public override bool EhValido()
        {
            ValidationResult = new NutricionistaAdicionarValidation(userService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
