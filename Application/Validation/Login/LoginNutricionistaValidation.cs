using Application.Commands.Login;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Login
{
    public class LoginNutricionistaValidation : AbstractValidator<LoginNutricionistaCommand>
    {
        public LoginNutricionistaValidation()
        {
            RuleFor(c => c.loginNutricionistaViewModel.Email)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Email"));

            RuleFor(c => c.loginNutricionistaViewModel.Senha)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));
        }
    }
}
