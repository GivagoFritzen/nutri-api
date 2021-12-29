using Application.Pacientes.Commands;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Pacientes
{
    public class PacienteValidation : AbstractValidator<AdicionarPacienteCommand>
    {
        public PacienteValidation()
        {
            RuleFor(c => c.pacienteViewModel.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(c => c.pacienteViewModel.Email).ValidarEmail();
        }
    }
}
