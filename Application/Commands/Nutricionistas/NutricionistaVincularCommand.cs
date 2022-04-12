using Application.Validation.Nutricionistas;
using Application.ViewModel.Nutricionistas;
using Core.Interfaces.Services;

namespace Application.Commands.Nutricionistas
{
    public class NutricionistaVincularCommand : Command
    {
        public NutricionistaVincularViewModel nutricionistaViewModel { get; private set; }
        private readonly IUserService userService;

        public NutricionistaVincularCommand(
            NutricionistaVincularViewModel nutricionistaViewModel,
            IUserService userService)
        {
            this.nutricionistaViewModel = nutricionistaViewModel;
            this.userService = userService;
        }

        public override bool EhValido()
        {
            ValidationResult = new NutricionistaVincularValidation(userService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
