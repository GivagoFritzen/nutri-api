using Application.Commands.Admin;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Admin
{
    public class AdminAdicionarValidation : AbstractValidator<AdminAdicionarCommand>
    {
        public AdminAdicionarValidation(IUserService userService)
        {
            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await userService.VerificarEmailExiste(x.adminAdicionarViewModel.Email) == false)
                .WithMessage(GenericValidationMessages.EmailCadastrado);

            RuleFor(c => c.adminAdicionarViewModel.Email).ValidarEmail();

            RuleFor(c => c.adminAdicionarViewModel.Senha)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));
        }
    }
}
