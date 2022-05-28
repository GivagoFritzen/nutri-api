using Application.Validation.Nutricionistas;
using Application.ViewModel.Nutricionistas;
using Domain.Interface.Repository;
using Domain.Interface.Services;

namespace Application.Commands.Nutricionistas
{
    public class NutricionistaAtualizarCommand : UserCommand
    {
        public NutricionistaAtualizarViewModel nutricionistaViewModel { get; private set; }
        private ISecurityService securityService;
        private readonly IUserRepository userRepository;

        public NutricionistaAtualizarCommand(
            ISecurityService securityService,
            NutricionistaAtualizarViewModel nutricionistaViewModel,
            IUserRepository userRepository)
        {
            this.securityService = securityService;
            this.nutricionistaViewModel = nutricionistaViewModel;
            this.userRepository = userRepository;
        }

        public override bool EhValido()
        {
            ValidationResult = new NutricionistaAtualizarValidation(securityService, userRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
