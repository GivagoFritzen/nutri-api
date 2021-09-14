using Application.Validation.Nutricionistas;
using Application.ViewModel.Nutricionistas;
using Core.Interfaces.Services;

namespace Application.Commands.Nutricionistas
{
    public class NutricionistaAtualizarCommand : UserCommand
    {
        private ISecurityService securityService;
        public NutricionistaAtualizarViewModel nutricionistaViewModel { get; private set; }

        public NutricionistaAtualizarCommand(ISecurityService securityService, NutricionistaAtualizarViewModel nutricionistaViewModel)
        {
            this.securityService = securityService;
            this.nutricionistaViewModel = nutricionistaViewModel;
        }

        public override bool EhValido()
        {
            ValidationResult = new NutricionistaAtualizarValidation(securityService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
