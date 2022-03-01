using Application.Pacientes.Commands;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Pacientes
{
    public class PacienteAtualizarValidation : AbstractValidator<PacienteAtualizarCommand>
    {
        public PacienteAtualizarValidation(IUserService userService)
        {
            RuleFor(c => c.pacienteViewModel.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(c => c.pacienteViewModel.Email)
                .ValidarEmail();

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await userService.VerificarEmailExiste(
                    x.pacienteViewModel.Email,
                    x.pacienteViewModel.Id
                ) == false)
                .WithMessage(GenericValidationMessages.EmailCadastrado);
        }
    }
}
