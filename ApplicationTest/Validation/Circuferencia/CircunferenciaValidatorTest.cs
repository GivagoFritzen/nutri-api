using Application.Validation.Circunferencia;
using Application.ViewModel.Medidas;
using ApplicationTest.ViewModel.Circunferencia;
using CrossCutting.Message.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ApplicationTest.Validation.Circuferencia
{
    [TestClass]
    public class CircunferenciaValidatorTest
    {
        private readonly CircunferenciaValidator circunferenciaValidator = new CircunferenciaValidator();

        [TestMethod]
        public void Validar()
        {
            var result = circunferenciaValidator.Validate(CircunferenciaViewModelFake.GetFake());
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Invalidos()
        {
            var result = circunferenciaValidator.Validate(new CircunferenciaViewModel());
            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain("BracoRelaxadoDireito - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("BracoRelaxadoEsquerdo - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("BracoContraidoDireito - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("BracoContraidoEsquerdo - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("AntebracoDireito - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("AntebracoEsquerdo - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("PunhoDireito - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("PunhoEsquerdo - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("Pescoco - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("Ombro - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("Peitoral - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("Cintura - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("Abdomen - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("Quadril - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("PanturrilhaDireita - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("PanturrilhaEsquerda - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("CoxaDireita - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("CoxaEsquerda - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("CoxaProximalDireita - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("CoxaProximalEsquerda - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
        }
    }
}
