using Application.Validation.Pacientes;
using ApplicationTest.Command.Pacientes;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTest.Validation.Pacientes
{
    [TestClass]
    public class PacienteAtualizarValidationTest
    {
        private Mock<IUserService> userServiceMock = new Mock<IUserService>();

        [TestMethod]
        public void Validar()
        {
            var validation = new PacienteAtualizarValidation(userServiceMock.Object);
            var result = validation.Validate(PacienteAtualizarCommandFake.GetFake());
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Nome_Invalido()
        {
            var validation = new PacienteAtualizarValidation(userServiceMock.Object);
            var result = validation.Validate(PacienteAtualizarCommandFake.GetNomeVazioFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

        }

        [TestMethod]
        public void Email_Existe()
        {
            userServiceMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>(), It.IsAny<Guid>())).Returns(Task.FromResult(true));

            var validation = new PacienteAtualizarValidation(userServiceMock.Object);
            var result = validation.Validate(PacienteAtualizarCommandFake.GetFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.EmailCadastrado);
        }

        [TestMethod]
        public void Email_Caracteres_Abaixo_Do_Permitido()
        {
            var validation = new PacienteAtualizarValidation(userServiceMock.Object);
            var result = validation.Validate(PacienteAtualizarCommandFake.GetEmailAbaixoDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMinimo, "Email", 5));
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }

        [TestMethod]
        public void Email_Caracteres_Acima_Do_Permitido()
        {
            var validation = new PacienteAtualizarValidation(userServiceMock.Object);
            var result = validation.Validate(PacienteAtualizarCommandFake.GetEmailAcimaDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMaximo, "Email", 254));
        }

        [TestMethod]
        public void Email_Invalido()
        {
            var validation = new PacienteAtualizarValidation(userServiceMock.Object);
            var result = validation.Validate(PacienteAtualizarCommandFake.GetEmailRequisitosInvalidosFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }
    }
}
