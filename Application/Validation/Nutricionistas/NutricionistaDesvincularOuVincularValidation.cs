using Application.Commands.Nutricionistas;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using FluentValidation;

namespace Application.Validation.Nutricionistas
{
    public class NutricionistaDesvincularOuVincularValidation : AbstractValidator<NutricionistaDesvincularOuVincularCommand>
    {
        public NutricionistaDesvincularOuVincularValidation(IUserRepository userRepository)
        {
            RuleFor(c => c.nutricionistaViewModel.Id)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Id"));

            RuleFor(c => c.nutricionistaViewModel.PacienteEmail)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Email"));

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await userRepository.VerificarEmailExiste(
                    x.nutricionistaViewModel.PacienteEmail,
                    "Paciente"
                )).WithMessage(GenericValidationMessages.EmailInvalido);
        }
    }
}
