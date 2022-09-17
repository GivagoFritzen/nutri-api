using Application.Commands.Pacientes;
using Application.Validation.Pacientes;
using Application.ViewModel.Pacientes;
using Application.ViewModel.Refeicao;
using ApplicationTest.Command.Pacientes;
using ApplicationTest.ViewModel.Refeicao;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using DomainTest.Event;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTest.Validation.Pacientes
{
    [TestClass]
    public class PacientePlanoAlimentarValidationTest
    {
        private Mock<IPacienteRepository> pacienteRepositoryMock = new Mock<IPacienteRepository>();

        [TestInitialize]
        public void Initialize()
        {
            pacienteRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(PacienteEventFake.GetPacienteEventFake()));
        }

        [TestMethod]
        public void Validar()
        {
            var validation = new PacientePlanoAlimentarValidation(pacienteRepositoryMock.Object);
            var result = validation.Validate(PacientePlanoAlimentarCommandFake.GetFake());
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Validar_Guid_Inexistente()
        {
            var validation = new PacientePlanoAlimentarValidation(new Mock<IPacienteRepository>().Object);
            var result = validation.Validate(PacientePlanoAlimentarCommandFake.GetFake());

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.NaoEncontrado, "Usuário"));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetRefeicoesInvalida), DynamicDataSourceType.Method)]
        public void Validar_Refeicao_Invalido(PacientePlanoAlimentarCommand command)
        {
            var validation = new PacientePlanoAlimentarValidation(pacienteRepositoryMock.Object);
            var result = validation.Validate(command);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Refeicao"));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetRefeicoesDescricaoInvalida), DynamicDataSourceType.Method)]
        public void Validar_Refeicao_Descricao_Invalida(List<RefeicaoViewModel> refeicoesViewModel)
        {
            var command = new PacientePlanoAlimentarCommand(
                new PacientePlanoAlimentarViewModel()
                {
                    PacienteId = Guid.NewGuid(),
                    Refeicoes = refeicoesViewModel
                },
                pacienteRepositoryMock.Object);

            var validation = new PacientePlanoAlimentarValidation(pacienteRepositoryMock.Object);
            var result = validation.Validate(command);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Descricao"));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetRefeicoesAlimentosInvalida), DynamicDataSourceType.Method)]
        public void Validar_Alimento_Invalido(List<RefeicaoViewModel> refeicoesViewModel)
        {
            var command = new PacientePlanoAlimentarCommand(
                new PacientePlanoAlimentarViewModel()
                {
                    PacienteId = Guid.NewGuid(),
                    Refeicoes = refeicoesViewModel
                },
                pacienteRepositoryMock.Object);

            var validation = new PacientePlanoAlimentarValidation(pacienteRepositoryMock.Object);
            var result = validation.Validate(command);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Alimentos"));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetRefeicoesAlimentosNomesInvalida), DynamicDataSourceType.Method)]
        public void Validar_Alimento_Nome_Invalido(List<RefeicaoViewModel> refeicoesViewModel)
        {
            var command = new PacientePlanoAlimentarCommand(
                new PacientePlanoAlimentarViewModel()
                {
                    PacienteId = Guid.NewGuid(),
                    Refeicoes = refeicoesViewModel
                },
                pacienteRepositoryMock.Object);

            var validation = new PacientePlanoAlimentarValidation(pacienteRepositoryMock.Object);
            var result = validation.Validate(command);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetRefeicoesAlimentosQuantidadeInvalida), DynamicDataSourceType.Method)]
        public void Validar_Alimento_Quantidade_Invalido(List<RefeicaoViewModel> refeicoesViewModel)
        {
            var command = new PacientePlanoAlimentarCommand(
                new PacientePlanoAlimentarViewModel()
                {
                    PacienteId = Guid.NewGuid(),
                    Refeicoes = refeicoesViewModel
                },
                pacienteRepositoryMock.Object);

            var validation = new PacientePlanoAlimentarValidation(pacienteRepositoryMock.Object);
            var result = validation.Validate(command);

            var erros = result.Errors.Select(x => x.ErrorMessage);
            erros.Should().Contain(string.Format(GenericValidationMessages.ValorMinimo, "0"));
        }


        private static IEnumerable<object[]> GetRefeicoesInvalida()
        {
            yield return new object[] { PacientePlanoAlimentarCommandFake.GetFakeRefeicaoNull() };
            yield return new object[] { PacientePlanoAlimentarCommandFake.GetFakeRefeicaoEmpty() };
        }

        private static IEnumerable<object[]> GetRefeicoesDescricaoInvalida()
        {
            yield return new object[] { new List<RefeicaoViewModel>() { RefeicaoViewModelFake.GetFakeDescricaoNull() } };
            yield return new object[] { new List<RefeicaoViewModel>() { RefeicaoViewModelFake.GetFakeDescricaoVazia() } };
        }

        private static IEnumerable<object[]> GetRefeicoesAlimentosInvalida()
        {
            yield return new object[] { new List<RefeicaoViewModel>() { RefeicaoViewModelFake.GetFakeAlimentoNull() } };
            yield return new object[] { new List<RefeicaoViewModel>() { RefeicaoViewModelFake.GetFakeAlimentoVazia() } };
        }

        private static IEnumerable<object[]> GetRefeicoesAlimentosNomesInvalida()
        {
            yield return new object[] { new List<RefeicaoViewModel>() { RefeicaoViewModelFake.GetFakeAlimentoNomeEmpty() } };
            yield return new object[] { new List<RefeicaoViewModel>() { RefeicaoViewModelFake.GetFakeAlimentoNomeNull() } };
        }

        private static IEnumerable<object[]> GetRefeicoesAlimentosQuantidadeInvalida()
        {
            yield return new object[] { new List<RefeicaoViewModel>() { RefeicaoViewModelFake.GetFakeAlimentoQuantidadeNegativa() } };
            yield return new object[] { new List<RefeicaoViewModel>() { RefeicaoViewModelFake.GetFakeAlimentoQuantidadeZero() } };
        }
    }
}
