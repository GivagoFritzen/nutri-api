using Application.Commands.Medidas;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using FluentValidation;

namespace Application.Validation.Medidas
{
    public class MedidaAdicionarValidation : AbstractValidator<MedidaAdicionarCommand>
    {
        public MedidaAdicionarValidation(IPacienteRepository pacienteRepository)
        {
            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await pacienteRepository.GetById(
                    x.medidaAdicionarViewModel.PacienteId
                ) is not null)
                .WithMessage(string.Format(GenericValidationMessages.NaoEncontrado, "Paciente"));

            RuleFor(c => c.medidaAdicionarViewModel.Medida)
                .SetValidator(new MedidaGenericValidator());
        }
    }
}
