using Application.Commands.Nutricionistas;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using FluentValidation;

namespace Application.Validation.Nutricionistas
{
    public class NutricionistaAdicionarValidation : AbstractValidator<NutricionistaAdicionarCommand>
    {
        public NutricionistaAdicionarValidation(IUserRepository userRepository)
        {
            RuleFor(c => c.nutricionistaViewModel.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(c => c.nutricionistaViewModel.Senha)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await userRepository.VerificarEmailExiste(x.nutricionistaViewModel.Email) == false)
                .WithMessage(GenericValidationMessages.EmailCadastrado);

            RuleFor(c => c.nutricionistaViewModel.Email).ValidarEmail();
        }
    }
}
