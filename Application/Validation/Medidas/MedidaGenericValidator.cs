using Application.Validation.Circunferencia;
using Application.ViewModel.Medidas;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Medidas
{
    public class MedidaGenericValidator : AbstractValidator<MedidaViewModel>
    {
        public MedidaGenericValidator()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Descricao"));

            RuleFor(c => c.PesoAtual)
                .GreaterThan(0)
                .WithMessage("PesoAtual - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.PesoIdeal)
                .GreaterThan(0)
                .WithMessage("PesoIdeal - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.Altura)
                .GreaterThan(0)
                .WithMessage("Altura - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.Circunferencia)
                .SetValidator(new CircunferenciaValidator());
        }
    }
}
