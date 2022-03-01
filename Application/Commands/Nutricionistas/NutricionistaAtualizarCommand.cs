using Application.Validation.Nutricionistas;
using Application.ViewModel.Nutricionistas;
using Core.Interfaces.Services;

namespace Application.Commands.Nutricionistas
{
    public class NutricionistaAtualizarCommand : UserCommand
    {
        public NutricionistaAtualizarViewModel nutricionistaViewModel { get; private set; }
        private ISecurityService securityService;
        private readonly IUserService userService;

        public NutricionistaAtualizarCommand(
            ISecurityService securityService,
            NutricionistaAtualizarViewModel nutricionistaViewModel,
            IUserService userService)
        {
            this.securityService = securityService;
            this.nutricionistaViewModel = nutricionistaViewModel;
            this.userService = userService;
        }

        public override bool EhValido()
        {
            ValidationResult = new NutricionistaAtualizarValidation(securityService, userService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
