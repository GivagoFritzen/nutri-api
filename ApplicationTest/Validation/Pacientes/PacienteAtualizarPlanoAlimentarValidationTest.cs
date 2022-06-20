using Application.Validation.Pacientes;
using ApplicationTest.Command.Pacientes;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTest.Validation.Pacientes
{
    [TestClass]
    public class PacienteAtualizarPlanoAlimentarValidationTest
    {
        [TestMethod]
        public void Validar()
        {
            var planoAlimentarRepositoryMock = new Mock<IPlanoAlimentarRepository>();
            planoAlimentarRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(PlanoAlimentarEntityFake.GetFake()));

            var validation = new PacienteAtualizarPlanoAlimentarValidation(planoAlimentarRepositoryMock.Object);
            var result = validation.Validate(PacienteAtualizarPlanoAlimentarCommandFake.GetFake());

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Invalida()
        {
            var validation = new PacienteAtualizarPlanoAlimentarValidation(new Mock<IPlanoAlimentarRepository>().Object);
            var result = validation.Validate(PacienteAtualizarPlanoAlimentarCommandFake.GetFake());

            Assert.IsFalse(result.IsValid);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.NaoEncontrado, "Plano Alimentar"));
        }
    }
}
