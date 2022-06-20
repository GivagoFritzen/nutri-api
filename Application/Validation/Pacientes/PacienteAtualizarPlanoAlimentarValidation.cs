using Application.Commands.Pacientes;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using FluentValidation;

namespace Application.Validation.Pacientes
{
    public class PacienteAtualizarPlanoAlimentarValidation : AbstractValidator<PacienteAtualizarPlanoAlimentarCommand>
    {
        public PacienteAtualizarPlanoAlimentarValidation(IPlanoAlimentarRepository planoAlimentarRepository)
        {
            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await planoAlimentarRepository.GetById(
                    x.pacienteAtualizarPlanoAlimentarViewModel.PlanoAlimentarId
                ) is not null)
                .WithMessage(string.Format(GenericValidationMessages.NaoEncontrado, "Plano Alimentar"));
        }
    }
}
