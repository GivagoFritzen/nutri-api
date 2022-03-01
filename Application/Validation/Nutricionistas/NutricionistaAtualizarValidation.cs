using Application.Commands.Nutricionistas;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Nutricionistas
{
    public class NutricionistaAtualizarValidation : AbstractValidator<NutricionistaAtualizarCommand>
    {
        public NutricionistaAtualizarValidation(ISecurityService securityService, IUserService userService)
        {
            RuleFor(c => c.nutricionistaViewModel.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(c => c.nutricionistaViewModel.AntigaSenha)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));

            RuleFor(c => c.nutricionistaViewModel.NovaSenha)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));

            RuleFor(c => c.nutricionistaViewModel.Email).ValidarEmail();

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await userService.VerificarEmailExiste(
                    x.nutricionistaViewModel.Email,
                    x.nutricionistaViewModel.Id
                ) == false)
                .WithMessage(GenericValidationMessages.EmailCadastrado);

            RuleFor(c => c)
                .ValidarNovaSenha(securityService);
        }
    }
}
