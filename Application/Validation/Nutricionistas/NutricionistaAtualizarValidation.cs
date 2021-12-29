using Application.Commands.Nutricionistas;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Nutricionistas
{
    public class NutricionistaAtualizarValidation : AbstractValidator<NutricionistaAtualizarCommand>
    {
        public NutricionistaAtualizarValidation(ISecurityService securityService)
        {
            RuleFor(c => c.nutricionistaViewModel.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(c => c.nutricionistaViewModel.AntigaSenha)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));

            RuleFor(c => c.nutricionistaViewModel.Email).ValidarEmail();

            RuleFor(c => c)
                .ValidarNovaSenha(securityService);
        }
    }
}
