using Application.Pacientes.Commands;
using FluentValidation;

namespace Application.Validation
{
    public class PacienteValidation : AbstractValidator<AdicionarPacienteCommand>
    {
        public PacienteValidation()
        {
            RuleFor(c => c.pacienteViewModel.Nome)
                .NotEmpty()
                .WithMessage("O nome do paciente não foi informado");
        }
    }
}
