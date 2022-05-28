using Application.Commands.Nutricionistas;
using Domain.Interface.Services;
using CrossCutting.Message.Validation;
using FluentValidation;
using Domain.Interface.Repository;

namespace Application.Validation.Nutricionistas
{
    public class NutricionistaAtualizarValidation : AbstractValidator<NutricionistaAtualizarCommand>
    {
        public NutricionistaAtualizarValidation(ISecurityService securityService, IUserRepository userRepository)
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
                .MustAsync(async (x, cancellation) => await userRepository.VerificarEmailExiste(
                    x.nutricionistaViewModel.Email,
                    x.nutricionistaViewModel.Id
                ) == false)
                .WithMessage(GenericValidationMessages.EmailCadastrado);

            RuleFor(c => c)
                .ValidarNovaSenha(securityService);
        }
    }
}
