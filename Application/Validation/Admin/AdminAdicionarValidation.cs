using Application.Commands.Admin;
using CrossCutting.Message.Validation;
using FluentValidation;
using Services;

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
        }
    }
}
