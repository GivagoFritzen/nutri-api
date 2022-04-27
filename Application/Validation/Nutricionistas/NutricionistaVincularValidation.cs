using Application.Commands.Nutricionistas;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Nutricionistas
{
    public class NutricionistaVincularValidation : AbstractValidator<NutricionistaVincularCommand>
    {
        public NutricionistaVincularValidation(IUserService userService)
        {
            RuleFor(c => c.nutricionistaViewModel.Id)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Id"));

            RuleFor(c => c.nutricionistaViewModel.PacienteEmail)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Email"));

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await userService.VerificarEmailExiste(
                    x.nutricionistaViewModel.PacienteEmail,
                    "Paciente"
                )).WithMessage(GenericValidationMessages.EmailInvalido);
        }
    }
}
