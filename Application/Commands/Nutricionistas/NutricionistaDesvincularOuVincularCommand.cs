using Application.Validation.Nutricionistas;
using Application.ViewModel.Nutricionistas;
using Core.Interfaces.Services;

namespace Application.Commands.Nutricionistas
{
    public class NutricionistaDesvincularOuVincularCommand : Command
    {
        public NutricionistaDesvincularOuVincularViewModel nutricionistaViewModel { get; private set; }
        private readonly IUserService userService;

        public NutricionistaDesvincularOuVincularCommand(
            NutricionistaDesvincularOuVincularViewModel nutricionistaViewModel,
            IUserService userService)
        {
            this.nutricionistaViewModel = nutricionistaViewModel;
            this.userService = userService;
        }

        public override bool EhValido()
        {
            ValidationResult = new NutricionistaDesvincularOuVincularValidation(userService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
