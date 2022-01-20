using Application.Commands.Nutricionistas;
using CrossCutting.Message.Validation;
using FluentValidation;
using Services;

namespace Application.Validation.Nutricionistas
{
    public class NutricionistaAdicionarValidation : AbstractValidator<NutricionistaAdicionarCommand>
    {
        public NutricionistaAdicionarValidation(IUserService userService)
        {
            RuleFor(c => c.nutricionistaViewModel.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await userService.VerificarEmailExiste(x.nutricionistaViewModel.Email) == false)
                .WithMessage(GenericValidationMessages.EmailCadastrado);

            RuleFor(c => c.nutricionistaViewModel.Email).ValidarEmail();
        }
    }
}
