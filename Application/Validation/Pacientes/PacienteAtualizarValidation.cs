using Application.Pacientes.Commands;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using FluentValidation;

namespace Application.Validation.Pacientes
{
    public class PacienteAtualizarValidation : AbstractValidator<PacienteAtualizarCommand>
    {
        public PacienteAtualizarValidation(IUserRepository userRepository)
        {
            RuleFor(c => c.pacienteViewModel.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(c => c.pacienteViewModel.Email)
                .ValidarEmail();

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await userRepository.VerificarEmailExiste(
                    x.pacienteViewModel.Email,
                    x.pacienteViewModel.Id
                ) == false)
                .WithMessage(GenericValidationMessages.EmailCadastrado);
        }
    }
}
