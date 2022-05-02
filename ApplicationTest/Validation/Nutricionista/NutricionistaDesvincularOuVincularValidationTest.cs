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
    public class NutricionistaDesvincularOuVincularValidationTest
    {
        private Mock<IUserService> userServiceMock = new Mock<IUserService>();

        [TestMethod]
        public void Validar()
        {
            userServiceMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));

            var validation = new NutricionistaDesvincularOuVincularValidation(userServiceMock.Object);
            var result = validation.Validate(NutricionistaDesvincularOuVincularCommandFake.GetFake());

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Validar_Id_Vazio()
        {
            var validation = new NutricionistaDesvincularOuVincularValidation(userServiceMock.Object);
            var result = validation.Validate(NutricionistaDesvincularOuVincularCommandFake.GetFakeIdVazio());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Id"));
        }

        [TestMethod]
        public void Validar_Email_Vazio()
        {
            userServiceMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(false));
            var validation = new NutricionistaDesvincularOuVincularValidation(userServiceMock.Object);

            var result = validation.Validate(NutricionistaDesvincularOuVincularCommandFake.GetFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.EmailInvalido);
        }
    }
}
