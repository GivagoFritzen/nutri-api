using Application.Validation.Pacientes;
using ApplicationTest.Command.Pacientes;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTest.Validation.Pacientes
{
    [TestClass]
    public class PacienteAdicionarValidationTest
    {
        private Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

        [TestMethod]
        public void Validar()
        {
            var validation = new PacienteAdicionarValidation(userRepositoryMock.Object);
            var result = validation.Validate(PacienteAdicionarCommandFake.GetFake());
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Nome_Invalido()
        {
            var validation = new PacienteAdicionarValidation(userRepositoryMock.Object);
            var result = validation.Validate(PacienteAdicionarCommandFake.GetNomeVazioFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

        }

        [TestMethod]
        public void Email_Existe()
        {
            userRepositoryMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>())).Returns(Task.FromResult(true));

            var validation = new PacienteAdicionarValidation(userRepositoryMock.Object);
            var result = validation.Validate(PacienteAdicionarCommandFake.GetFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.EmailCadastrado);
        }

        [TestMethod]
        public void Email_Caracteres_Abaixo_Do_Permitido()
        {
            var validation = new PacienteAdicionarValidation(userRepositoryMock.Object);
            var result = validation.Validate(PacienteAdicionarCommandFake.GetEmailAbaixoDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMinimo, "Email", 5));
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }

        [TestMethod]
        public void Email_Caracteres_Acima_Do_Permitido()
        {
            var validation = new PacienteAdicionarValidation(userRepositoryMock.Object);
            var result = validation.Validate(PacienteAdicionarCommandFake.GetEmailAcimaDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMaximo, "Email", 254));
        }

        [TestMethod]
        public void Email_Invalido()
        {
            var validation = new PacienteAdicionarValidation(userRepositoryMock.Object);
            var result = validation.Validate(PacienteAdicionarCommandFake.GetEmailRequisitosInvalidosFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }
    }
}
