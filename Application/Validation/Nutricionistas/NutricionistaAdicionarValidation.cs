using Application.Commands.Nutricionistas;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Nutricionistas
{
    public class NutricionistaAdicionarValidation : AbstractValidator<NutricionistaAdicionarCommand>
    {
        public NutricionistaAdicionarValidation()
        {
            RuleFor(c => c.nutricionistaViewModel.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(c => c.nutricionistaViewModel.Email).ValidarEmail();
        }
    }
}
