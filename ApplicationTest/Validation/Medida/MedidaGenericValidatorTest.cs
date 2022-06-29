using Application.Validation.Medidas;
using Application.ViewModel.Medidas;
using ApplicationTest.ViewModel.Medida;
using CrossCutting.Message.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ApplicationTest.Validation.Medida
{
    [TestClass]
    public class MedidaGenericValidatorTest
    {
        private readonly MedidaGenericValidator medidaGenericValidator = new MedidaGenericValidator();

        [TestMethod]
        public void Validar()
        {
            var result = medidaGenericValidator.Validate(MedidaViewModelFake.GetFake());
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Invalidos()
        {
            var result = medidaGenericValidator.Validate(new MedidaViewModel());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Descricao"));
            erros.Should().Contain("PesoAtual - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("PesoIdeal - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            erros.Should().Contain("Altura - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
        }
    }
}
