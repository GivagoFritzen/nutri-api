using Application.Validation.Nutricionistas;
using ApplicationTest.Command.Nutricionistas;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTest.Validation.Nutricionista
{
    [TestClass]
    public class NutricionistaAdicionarValidationTest
    {
        private Mock<IUserService> userServiceMock = new Mock<IUserService>();

        [TestMethod]
        public void Validar()
        {
            var validation = new NutricionistaAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(NutricionistaAdicionarCommandFake.GetFake());
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Nome_Invalido()
        {
            var validation = new NutricionistaAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(NutricionistaAdicionarCommandFake.GetNomeVazioFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));
        }

        [TestMethod]
        public void Senha_Invalida()
        {
            var validation = new NutricionistaAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(NutricionistaAdicionarCommandFake.GetSenhaInvalidaFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));
        }

        [TestMethod]
        public void Email_Existe()
        {
            userServiceMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>())).Returns(Task.FromResult(true));

            var validation = new NutricionistaAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(NutricionistaAdicionarCommandFake.GetFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.EmailCadastrado);
        }

        [TestMethod]
        public void Email_Caracteres_Abaixo_Do_Permitido()
        {
            var validation = new NutricionistaAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(NutricionistaAdicionarCommandFake.GetEmailAbaixoDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMinimo, "Email", 5));
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }

        [TestMethod]
        public void Email_Caracteres_Acima_Do_Permitido()
        {
            var validation = new NutricionistaAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(NutricionistaAdicionarCommandFake.GetEmailAcimaDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMaximo, "Email", 254));
        }

        [TestMethod]
        public void Email_Invalido()
        {
            var validation = new NutricionistaAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(NutricionistaAdicionarCommandFake.GetEmailRequisitosInvalidosFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }
    }
}
