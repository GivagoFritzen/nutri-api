using Application.Commands;
using FluentValidation;
using System;

namespace Application.Validation
{
    public class PacienteValidation : AbstractValidator<PacienteCommand>
    {
        public PacienteValidation()
        {
            RuleFor(c => c.pacienteViewModel.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do paciente inválido");

            RuleFor(c => c.pacienteViewModel.Nome)
                .NotEmpty()
                .WithMessage("O nome do paciente não foi informado");
        }
    }
}
