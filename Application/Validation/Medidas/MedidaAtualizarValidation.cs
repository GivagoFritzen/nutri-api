using Application.Commands.Medidas;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using FluentValidation;

namespace Application.Validation.Medidas
{
    public class MedidaAtualizarValidation : AbstractValidator<MedidaAtualizarCommand>
    {
        public MedidaAtualizarValidation(IMedidaRepository medidaRepository, IPacienteRepository pacienteRepository)
        {
            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await pacienteRepository.GetById(
                    x.medidaAtualizarViewModel.PacienteId
                ) is not null)
                .WithMessage(string.Format(GenericValidationMessages.NaoEncontrado, "Paciente"));

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await medidaRepository.GetById(
                    x.medidaAtualizarViewModel.MedidaId
                ) is not null)
                .WithMessage(string.Format(GenericValidationMessages.NaoEncontrado, "Medida"));

            RuleFor(c => c.medidaAtualizarViewModel.Medida)
                .SetValidator(new MedidaGenericValidator());
        }
    }
}
