using Application.Validation.Nutricionistas;
using ApplicationTest.Command.Nutricionistas;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTest.Validation.Nutricionista
{
    [TestClass]
    public class NutricionistaAtualizarValidationTest
    {
        private Mock<ISecurityService> securityServiceMock = new Mock<ISecurityService>();
        private Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

        [TestMethod]
        public void Validar()
        {
            var validation = new NutricionistaAtualizarValidation(securityServiceMock.Object, userRepositoryMock.Object);
            var result = validation.Validate(NutricionistaAtualizarCommandFake.GetFake());
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Nome_Invalido()
        {
            var validation = new NutricionistaAtualizarValidation(securityServiceMock.Object, userRepositoryMock.Object);
            var result = validation.Validate(NutricionistaAtualizarCommandFake.GetNomeVazioFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

        }

        [TestMethod]
        public void Senha_Antiga_Invalida()
        {
            var validation = new NutricionistaAtualizarValidation(securityServiceMock.Object, userRepositoryMock.Object);
            var result = validation.Validate(NutricionistaAtualizarCommandFake.GetSenhaAntigaInvalidaFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));
        }

        [TestMethod]
        public void Senha_Nova_Invalida()
        {
            var validation = new NutricionistaAtualizarValidation(securityServiceMock.Object, userRepositoryMock.Object);
            var result = validation.Validate(NutricionistaAtualizarCommandFake.GetSenhaNovaInvalidaFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Senha"));
        }

        [TestMethod]
        public void Email_Existe()
        {
            userRepositoryMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>(), It.IsAny<Guid>())).Returns(Task.FromResult(true));

            var validation = new NutricionistaAtualizarValidation(securityServiceMock.Object, userRepositoryMock.Object);
            var result = validation.Validate(NutricionistaAtualizarCommandFake.GetFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.EmailCadastrado);
        }

        [TestMethod]
        public void Email_Caracteres_Abaixo_Do_Permitido()
        {
            var validation = new NutricionistaAtualizarValidation(securityServiceMock.Object, userRepositoryMock.Object);
            var result = validation.Validate(NutricionistaAtualizarCommandFake.GetEmailAbaixoDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMinimo, "Email", 5));
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }

        [TestMethod]
        public void Email_Caracteres_Acima_Do_Permitido()
        {
            var validation = new NutricionistaAtualizarValidation(securityServiceMock.Object, userRepositoryMock.Object);
            var result = validation.Validate(NutricionistaAtualizarCommandFake.GetEmailAcimaDoPermitidoFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CaracteresMaximo, "Email", 254));
        }

        [TestMethod]
        public void Email_Invalido()
        {
            var validation = new NutricionistaAtualizarValidation(securityServiceMock.Object, userRepositoryMock.Object);
            var result = validation.Validate(NutricionistaAtualizarCommandFake.GetEmailRequisitosInvalidosFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(GenericValidationMessages.RequisitosEmail);
        }
    }
}