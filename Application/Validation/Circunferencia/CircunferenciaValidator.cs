using Application.ViewModel.Medidas;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation.Circunferencia
{
    public class CircunferenciaValidator : AbstractValidator<CircunferenciaViewModel>
    {
        public CircunferenciaValidator()
        {
            RuleFor(c => c.BracoRelaxadoDireito)
                .GreaterThan(0)
                .WithMessage("BracoRelaxadoDireito - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.BracoRelaxadoEsquerdo)
                .GreaterThan(0)
                .WithMessage("BracoRelaxadoEsquerdo - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.BracoContraidoDireito)
                .GreaterThan(0)
                .WithMessage("BracoContraidoDireito - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.BracoContraidoEsquerdo)
                .GreaterThan(0)
                .WithMessage("BracoContraidoEsquerdo - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));


            RuleFor(c => c.AntebracoDireito)
                .GreaterThan(0)
                .WithMessage("AntebracoDireito - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.AntebracoEsquerdo)
                .GreaterThan(0)
                .WithMessage("AntebracoEsquerdo - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));


            RuleFor(c => c.PunhoDireito)
                .GreaterThan(0)
                .WithMessage("PunhoDireito - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.PunhoEsquerdo)
                .GreaterThan(0)
                .WithMessage("PunhoEsquerdo - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));


            RuleFor(c => c.Pescoco)
                .GreaterThan(0)
                .WithMessage("Pescoco - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.Ombro)
                .GreaterThan(0)
                .WithMessage("Ombro - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.Peitoral)
                .GreaterThan(0)
                .WithMessage("Peitoral - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.Cintura)
                .GreaterThan(0)
                .WithMessage("Cintura - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.Abdomen)
                .GreaterThan(0)
                .WithMessage("Abdomen - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.Quadril)
                .GreaterThan(0)
                .WithMessage("Quadril - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));


            RuleFor(c => c.PanturrilhaDireita)
                .GreaterThan(0)
                .WithMessage("PanturrilhaDireita - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.PanturrilhaEsquerda)
                .GreaterThan(0)
                .WithMessage("PanturrilhaEsquerda - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.CoxaDireita)
                .GreaterThan(0)
                .WithMessage("CoxaDireita - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.CoxaEsquerda)
                .GreaterThan(0)
                .WithMessage("CoxaEsquerda - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.CoxaProximalDireita)
                .GreaterThan(0)
                .WithMessage("CoxaProximalDireita - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));

            RuleFor(c => c.CoxaProximalEsquerda)
                .GreaterThan(0)
                .WithMessage("CoxaProximalEsquerda - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
        }
    }
}
