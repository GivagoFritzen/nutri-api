using Application.Commands.Pacientes;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using FluentValidation;

namespace Application.Validation.Pacientes
{
    public class PacienteAdicionarValidation : AbstractValidator<PacienteAdicionarCommand>
    {
        public PacienteAdicionarValidation(IUserRepository userRepository)
        {
            RuleFor(c => c.pacienteViewModel.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(c => c.pacienteViewModel.Email)
                .ValidarEmail();

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await userRepository.VerificarEmailExiste(x.pacienteViewModel.Email) == false)
                .WithMessage(GenericValidationMessages.EmailCadastrado);
        }
    }
}
