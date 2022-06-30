using Application.Services;
using Application.ViewModel.Pacientes;
using ApplicationTest.ViewModel.Paciente;
using CrossCuttingTest;
using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using Domain.Repository;
using DomainTest.Entity;
using DomainTest.Event;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationTest.Services
{
    [TestClass]
    public class ApplicationServicePacienteTest
    {
        private ApplicationServicePaciente applicationService;

        [TestInitialize]
        public void Initialize()
        {
            applicationService = new ApplicationServicePaciente(
                new Mock<IPlanoAlimentarRepository>().Object,
                new Mock<IPacienteRepository>().Object,
                null,
                new Mock<IMessagingService>().Object,
                new Mock<IUserRepository>().Object);
        }

        [TestMethod]
        public async Task Add_Invalido()
        {
            var retorno = await applicationService.Add(PacienteAdicionarViewModelFake.GetNomeVazioFake());
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Add_Valido()
        {
            var model = PacienteAdicionarViewModelFake.GetFake();
            var retorno = (await applicationService.Add(model)).Body as PacienteViewModel;

            retorno.Should().BeEquivalentTo(model);
        }

        [TestMethod]
        public async Task Get_By_Id_Inexistente()
        {
            var mongoFake = new MongoFake<PacienteEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<PacienteEvent>().GetMongoDbContext(mongoFake);
            var pacienteRepository = new PacienteRepository(null, mongoDbContextoMock.Object);

            var applicationServicePaciente = new ApplicationServicePaciente(
                new Mock<IPlanoAlimentarRepository>().Object,
                pacienteRepository,
                null,
                new Mock<IMessagingService>().Object,
                new Mock<IUserRepository>().Object);

            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(() =>
                applicationServicePaciente.GetById(Guid.NewGuid())
            );
        }

        [TestMethod]
        public async Task Get_By_Id_Existente()
        {
            var mongoFake = new MongoFake<PacienteEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<PacienteEvent>().GetMongoDbContext(mongoFake);
            var pacienteRepository = new PacienteRepository(null, mongoDbContextoMock.Object);

            var applicationServicePaciente = new ApplicationServicePaciente(
                new Mock<IPlanoAlimentarRepository>().Object,
                pacienteRepository,
                null,
                new Mock<IMessagingService>().Object,
                new Mock<IUserRepository>().Object);

            var retorno = await applicationServicePaciente.GetById(PacienteEntityFake.Id);
            retorno.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Remove()
        {
            var pacienteRepositoryMock = new Mock<IPacienteRepository>();
            var messagingServiceMock = new Mock<IMessagingService>();

            var applicationServicePaciente = new ApplicationServicePaciente(
                new Mock<IPlanoAlimentarRepository>().Object,
                pacienteRepositoryMock.Object,
                null,
                messagingServiceMock.Object,
                new Mock<IUserRepository>().Object);

            await applicationServicePaciente.RemoveById(Guid.NewGuid());
            pacienteRepositoryMock.Verify(mock => mock.RemoveById(It.IsAny<Guid>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<UserEvent>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<PacienteEvent>()), Times.Once());
        }

        [TestMethod]
        public async Task Update_Invalido()
        {
            var retorno = await applicationService.Update(PacienteAtualizarViewModelFake.GetNomeVazioFake());
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Update_Valido()
        {
            var model = PacienteAtualizarViewModelFake.GetFake();
            var retorno = (await applicationService.Update(model)).Body as PacienteAtualizarViewModel;

            retorno.Should()
                .BeEquivalentTo(model, options =>
                    options.Excluding(_ => _.Id)
                );
        }

        [TestMethod]
        public async Task Adicionar_Plano_Alimentar_Invalido()
        {
            var retorno = await applicationService.AdicionarPlanoAlimentar(PacientePlanoAlimentarViewModelFake.GetFakeRefeicaoNull());
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Adicionar_Plano_Alimentar_Valido()
        {
            var messagingServiceMock = new Mock<IMessagingService>();
            var pacienteRepositoryMock = new Mock<IPacienteRepository>();
            pacienteRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(PacienteEventFake.GetPacienteEventFake()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                new Mock<IPlanoAlimentarRepository>().Object,
                pacienteRepositoryMock.Object,
                null,
                messagingServiceMock.Object,
                new Mock<IUserRepository>().Object);

            var model = PacientePlanoAlimentarViewModelFake.GetFake();
            var retorno = (await applicationServicePaciente.AdicionarPlanoAlimentar(model)).Body as PacientePlanoAlimentarViewModel;

            retorno.Should().BeEquivalentTo(model);

            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<PacienteEvent>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<UserEvent>()), Times.Once());
            pacienteRepositoryMock.Verify(mock => mock.Update(It.IsAny<PacienteEntity>()), Times.Once());
        }

        [TestMethod]
        public void Atualizar_Plano_Alimentar_Invalido()
        {
            var retorno = applicationService.AtualizarPlanoAlimentar(PacienteAtualizarPlanoAlimentarViewModelFake.GetFake());
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Atualizar_Plano_Alimentar_Valido()
        {
            var viewModel = PacienteAtualizarPlanoAlimentarViewModelFake.GetFake();

            var planoAlimentarRepositoryMock = new Mock<IPlanoAlimentarRepository>();
            planoAlimentarRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(PlanoAlimentarEntityFake.GetFake()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                planoAlimentarRepositoryMock.Object,
                new Mock<IPacienteRepository>().Object,
                null,
                new Mock<IMessagingService>().Object,
                new Mock<IUserRepository>().Object);

            var retorno = applicationServicePaciente.AtualizarPlanoAlimentar(viewModel);

            planoAlimentarRepositoryMock.Verify(mock => mock.Update(It.IsAny<PlanoAlimentarEntity>()), Times.Once());
        }
    }
}
