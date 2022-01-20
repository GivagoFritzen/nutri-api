using Application.Pacientes.Commands;
using CrossCutting.Message.Validation;
using FluentValidation;
using Services;

namespace Application.Validation.Pacientes
{
    public class PacienteAtualizarValidation : AbstractValidator<AtualizarPacienteCommand>
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
