using Application.Validation.Nutricionistas;
using Application.ViewModel.Nutricionistas;

namespace Application.Commands.Nutricionistas
{
    public class NutricionistaAdicionarCommand : Command
    {
        public NutricionistaAdicionarViewModel nutricionistaViewModel { get; private set; }

        public NutricionistaAdicionarCommand(NutricionistaAdicionarViewModel nutricionistaViewModel)
        {
            this.nutricionistaViewModel = nutricionistaViewModel;
        }

        public override bool EhValido()
        {
            ValidationResult = new NutricionistaAdicionarValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
