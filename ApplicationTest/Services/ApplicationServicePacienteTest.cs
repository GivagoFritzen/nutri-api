﻿using Application.Services;
using Application.ViewModel.Pacientes;
using ApplicationTest.ViewModel.Paciente;
using CrossCuttingTest;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using Domain.Repository;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
                new Mock<IPacienteRepository>().Object,
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

            retorno.Should()
                .BeEquivalentTo(model,
                options => options.Excluding(_ => _.Medida));
        }

        [TestMethod]
        public async Task Get_By_Id_Inexistente()
        {
            var mongoFake = new MongoFake<PacienteEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<PacienteEvent>().GetMongoDbContext(mongoFake);
            var pacienteRepository = new PacienteRepository(null, mongoDbContextoMock.Object);

            var applicationServicePaciente = new ApplicationServicePaciente(
                pacienteRepository,
                new Mock<IMessagingService>().Object,
                new Mock<IUserRepository>().Object);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
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
                pacienteRepository,
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
                pacienteRepositoryMock.Object,
                messagingServiceMock.Object,
                new Mock<IUserRepository>().Object);

            await applicationServicePaciente.RemoveById(Guid.NewGuid());
            pacienteRepositoryMock.Verify(mock => mock.RemoveById(It.IsAny<Guid>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<UserEvent>()), Times.Exactly(2));
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<PacienteEvent>()), Times.Once());
        }

        [TestMethod]
        public void Update_Invalido()
        {
            var retorno = applicationService.Update(PacienteAtualizarViewModelFake.GetNomeVazioFake());
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Update_Valido()
        {
            var model = PacienteAtualizarViewModelFake.GetFake();
            var retorno = applicationService.Update(model).Body as PacienteAtualizarViewModel;

            retorno.Should()
                .BeEquivalentTo(model, options =>
                    options.Excluding(_ => _.Id)
                );
        }
    }
}
