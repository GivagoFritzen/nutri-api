using Application.Validation.Login;
using ApplicationTest.Command.Login;
using CrossCutting.Message.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ApplicationTest.Validation.Login
{
    [TestClass]
    public class LoginNutricionistaValidationTest
    {
        LoginNutricionistaValidation validation = new LoginNutricionistaValidation();

        [TestMethod]
        public void Validar()
        {
            var result = validation.Validate(LoginNutricionistaCommandFake.GetFake());
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Senha_Invalida()
        {
            var result = validation.Validate(LoginNutricionistaCommandFake.GetSenhaInvalido());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));
        }

        [TestMethod]
        public void Email_Caracteres_Abaixo_Do_Permitido()
        {
            var result = validation.Validate(LoginNutricionistaCommandFake.GetEmailAbaixoDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMinimo, "Email", 5));
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }

        [TestMethod]
        public void Email_Caracteres_Acima_Do_Permitido()
        {
            var result = validation.Validate(LoginNutricionistaCommandFake.GetEmailAcimaDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMaximo, "Email", 254));
        }

        [TestMethod]
        public void Email_Invalido()
        {
            var result = validation.Validate(LoginNutricionistaCommandFake.GetEmailRequisitosInvalidosFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }
    }
}
