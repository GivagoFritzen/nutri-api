using Application.Validation.Admin;
using ApplicationTest.Command.Admin;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTest.Validation.Admin
{
    [TestClass]
    public class AdminAdicionarValidationTest
    {
        private Mock<IUserService> userServiceMock = new Mock<IUserService>();

        [TestMethod]
        public void Validar()
        {
            var validation = new AdminAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(AdminAdicionarCommandFake.GetFake());
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Senha_Invalida()
        {
            var validation = new AdminAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(AdminAdicionarCommandFake.GetSenhaInvalidaFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));
        }

        [TestMethod]
        public void Email_Existe()
        {
            userServiceMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>())).Returns(Task.FromResult(true));

            var validation = new AdminAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(AdminAdicionarCommandFake.GetFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.EmailCadastrado);
        }

        [TestMethod]
        public void Email_Caracteres_Abaixo_Do_Permitido()
        {
            var validation = new AdminAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(AdminAdicionarCommandFake.GetEmailAbaixoDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMinimo, "Email", 5));
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }

        [TestMethod]
        public void Email_Caracteres_Acima_Do_Permitido()
        {
            var validation = new AdminAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(AdminAdicionarCommandFake.GetEmailAcimaDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMaximo, "Email", 254));
        }

        [TestMethod]
        public void Email_Invalido()
        {
            var validation = new AdminAdicionarValidation(userServiceMock.Object);
            var result = validation.Validate(AdminAdicionarCommandFake.GetEmailRequisitosInvalidosFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }
    }
}
