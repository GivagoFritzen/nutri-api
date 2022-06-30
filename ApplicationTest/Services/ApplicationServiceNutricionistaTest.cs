using Application.Interfaces;
using Application.Services;
using Application.ViewModel.Nutricionistas;
using ApplicationTest.ViewModel.Login;
using ApplicationTest.ViewModel.Nutricionista;
using CrossCuttingTest;
using Domain.DTO.Token;
using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Base;
using Domain.Interface.Services;
using Domain.Repository;
using Domain.Services;
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
    public class ApplicationServiceNutricionistaTest
    {
        private ApplicationServiceNutricionista applicationService;

        [TestInitialize]
        public void Initialize()
        {
            applicationService = new ApplicationServiceNutricionista(
                new Mock<INutricionistaRepository>().Object,
                new Mock<IMessagingService>().Object,
                new SecurityService(),
                new Mock<IUserRepository>().Object,
                new Mock<IPacienteRepository>().Object,
                new Mock<IApplicationServicePaciente>().Object,
                new TokenService());
        }

        [TestMethod]
        public async Task Add_Invalido()
        {
            var retorno = await applicationService.Add(NutricionistaAdicionarViewModelFake.GetNomeVazioFake());
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Add_Valido()
        {
            var model = NutricionistaAdicionarViewModelFake.GetFake();
            var retorno = (await applicationService.Add(model)).Body as NutricionistaViewModel;

            retorno.Should()
                .BeEquivalentTo(model,
                options => options.Excluding(_ => _.Senha));
        }

        [TestMethod]
        public async Task Remove()
        {
            var nutricionistaRepositoryMock = new Mock<INutricionistaRepository>();
            var messagingServiceMock = new Mock<IMessagingService>();

            var application = GetApplicationServiceNutricionistaFake(
                nutricionistaRepositoryMock.Object, messagingServiceMock.Object);

            await application.RemoveById(Guid.NewGuid());
            nutricionistaRepositoryMock.Verify(mock => mock.RemoveById(It.IsAny<Guid>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<UserEvent>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<NutricionistaEvent>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_By_Id_Inexistente()
        {
            var mongoFake = new MongoFake<NutricionistaEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<NutricionistaEvent>().GetMongoDbContext(mongoFake);
            var nutricionistaRepository = new NutricionistaRepository(null, mongoDbContextoMock.Object);

            var applicationServiceNutricionista = GetApplicationServiceNutricionistaFake(nutricionistaRepository);

            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(() =>
                applicationServiceNutricionista.GetById(Guid.NewGuid())
            );
        }

        [TestMethod]
        public async Task Get_By_Id_Existente()
        {
            var mongoFake = new MongoFake<NutricionistaEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<NutricionistaEvent>().GetMongoDbContext(mongoFake);
            var nutricionistaRepository = new NutricionistaRepository(null, mongoDbContextoMock.Object);

            var applicationServiceNutricionista = GetApplicationServiceNutricionistaFake(nutricionistaRepository);

            var retorno = await applicationServiceNutricionista.GetById(NutricionistaEntityFake.Id);
            retorno.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Get_All_Vazio()
        {
            var nutricionistaRepositoryMock = new Mock<INutricionistaRepository>();

            var applicationServiceNutricionista = GetApplicationServiceNutricionistaFake(nutricionistaRepositoryMock.Object);

            var retorno = await applicationServiceNutricionista.GetAll();

            retorno.Should().BeEmpty();
            nutricionistaRepositoryMock.Verify(mock => mock.GetAll(), Times.Once());
        }

        [DataTestMethod]
        [DynamicData(nameof(GetVerificacoesInvalidosPacientes), DynamicDataSourceType.Method)]
        public async Task Get_Nutri_Sem_Pacientes(NutricionistaEvent nutricionista)
        {
            var nutricionistaRepositoryMock = new Mock<INutricionistaRepository>();
            nutricionistaRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(nutricionista));

            var applicationServiceNutricionista = GetApplicationServiceNutricionistaFake(nutricionistaRepositoryMock.Object);
            var result = await applicationServiceNutricionista.GetPacientes(new Guid());
            result.Should().BeNull();
        }

        [TestMethod]
        public async Task Get_Nutri_Com_Pacientes()
        {
            var nutricionistaRepositoryMock = new Mock<INutricionistaRepository>();
            nutricionistaRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(NutricionistaEventFake.GetFakeComPacientes()));

            var applicationServiceNutricionista = GetApplicationServiceNutricionistaFake(
                nutricionistaRepositoryMock.Object, null, null, null,
                await GetApplicationServicePaciente());
            var result = await applicationServiceNutricionista.GetPacientes(new Guid());
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public void Update_Invalido()
        {
            var retorno = applicationService.Update(NutricionistaAtualizarViewModelFake.GetNomeVazioFake());
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Update_Valido()
        {
            var model = NutricionistaAtualizarViewModelFake.GetFake();
            var retorno = applicationService.Update(model).Body as NutricionistaAtualizarViewModel;

            retorno.Should()
                .BeEquivalentTo(model, options =>
                    options.Excluding(_ => _.Id)
                    .Excluding(_ => _.AntigaSenha)
                    .Excluding(_ => _.NovaSenha)
                );
        }

        [TestMethod]
        public async Task VincularPaciente_Invalido()
        {
            var model = NutricionistaDesvincularOuVincularViewModelFake.GetFake();

            var retorno = await applicationService.VincularPaciente(model);
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task VincularPaciente_Valido()
        {
            var model = NutricionistaDesvincularOuVincularViewModelFake.GetFake();

            var mongoFake = new MongoFake<NutricionistaEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<NutricionistaEvent>().GetMongoDbContext(mongoFake);

            var userServiceMock = new Mock<IUserRepository>();
            userServiceMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));

            var pacienteServiceMock = new Mock<IPacienteRepository>();
            var paciente = PacienteEventFake.GetPacienteEventFake();
            pacienteServiceMock.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(Task.FromResult(paciente));
            pacienteServiceMock.Setup(x => x.GetAll()).Returns(Task.FromResult(PacienteEventFake.GetListPacienteEventFake(PacienteEventFake.MongoId)));

            var nutricionistaRepositoryMock = new Mock<IRepositorySQL<NutricionistaEntity>>();
            var nutricionistaRepository = new NutricionistaRepository(nutricionistaRepositoryMock.Object, mongoDbContextoMock.Object);

            var applicationServiceNutricionista = GetApplicationServiceNutricionistaFake(
                nutricionistaRepository, null,
                userServiceMock.Object, pacienteServiceMock.Object);

            var retorno = await applicationServiceNutricionista.VincularPaciente(model);
            nutricionistaRepositoryMock.Verify(mock => mock.Update(It.IsAny<NutricionistaEntity>()), Times.Once());
        }

        [TestMethod]
        public async Task VincularPaciente_Valido_Sem_Pacientes()
        {
            var model = NutricionistaDesvincularOuVincularViewModelFake.GetFake();

            var userServiceMock = new Mock<IUserRepository>();
            userServiceMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));

            var pacienteServiceMock = new Mock<IPacienteRepository>();
            var paciente = PacienteEventFake.GetPacienteEventFake();
            pacienteServiceMock.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(Task.FromResult(paciente));
            pacienteServiceMock.Setup(x => x.GetAll()).Returns(Task.FromResult(PacienteEventFake.GetListPacienteEventFake(PacienteEventFake.MongoId)));

            var nutricionista = NutricionistaEventFake.GetFake();
            nutricionista.PacientesIds = null;
            var nutricionistaRepositoryMock = new Mock<INutricionistaRepository>();
            nutricionistaRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(nutricionista));

            var applicationServiceNutricionista = GetApplicationServiceNutricionistaFake(
                nutricionistaRepositoryMock.Object, null,
                userServiceMock.Object, pacienteServiceMock.Object);

            var retorno = await applicationServiceNutricionista.VincularPaciente(model);
            nutricionistaRepositoryMock.Verify(mock => mock.Update(It.IsAny<NutricionistaEntity>()), Times.Once());
        }

        [TestMethod]
        public async Task DesvincularPaciente_Invalido()
        {
            var model = NutricionistaDesvincularOuVincularViewModelFake.GetFake();
            var retorno = await applicationService.DesvincularPaciente(model.PacienteEmail, TokenFake.TokenGeneric);
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task DesvincularPaciente_Valido()
        {
            var model = NutricionistaDesvincularOuVincularViewModelFake.GetFake();

            var mongoFake = new MongoFake<NutricionistaEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<NutricionistaEvent>().GetMongoDbContext(mongoFake);

            var userServiceMock = new Mock<IUserRepository>();
            userServiceMock.Setup(x => x.VerificarEmailExiste(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));

            var pacienteServiceMock = new Mock<IPacienteRepository>();
            pacienteServiceMock.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(Task.FromResult(PacienteEventFake.GetPacienteEventFake()));

            var nutricionistaRepositoryMock = new Mock<IRepositorySQL<NutricionistaEntity>>();
            var nutricionistaRepository = new NutricionistaRepository(nutricionistaRepositoryMock.Object, mongoDbContextoMock.Object);

            var applicationServiceNutricionista = new ApplicationServiceNutricionista(
                nutricionistaRepository,
                new Mock<IMessagingService>().Object,
                new SecurityService(),
                userServiceMock.Object,
                pacienteServiceMock.Object,
                new Mock<IApplicationServicePaciente>().Object,
                GetTokenServiceMock());

            var retorno = await applicationServiceNutricionista.DesvincularPaciente(model.PacienteEmail, TokenFake.TokenGeneric);
            nutricionistaRepositoryMock.Verify(mock => mock.Update(It.IsAny<NutricionistaEntity>()), Times.Once());
        }

        private ApplicationServiceNutricionista GetApplicationServiceNutricionistaFake(
            INutricionistaRepository nutricionistaRepository = null,
            IMessagingService messagingService = null,
            IUserRepository userService = null,
            IPacienteRepository pacienteService = null,
            IApplicationServicePaciente applicationServicePaciente = null,
            ITokenService tokenService = null)
        {
            return new ApplicationServiceNutricionista(
                nutricionistaRepository is null ? new Mock<INutricionistaRepository>().Object : nutricionistaRepository,
                messagingService is null ? new Mock<IMessagingService>().Object : messagingService,
                new SecurityService(),
                userService is null ? new Mock<IUserRepository>().Object : userService,
                pacienteService is null ? new Mock<IPacienteRepository>().Object : pacienteService,
                applicationServicePaciente is null ? new Mock<IApplicationServicePaciente>().Object : applicationServicePaciente,
                tokenService is null ? new Mock<ITokenService>().Object : tokenService);
        }

        private async Task<ApplicationServicePaciente> GetApplicationServicePaciente()
        {
            var mongoFake = new MongoFake<PacienteEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<PacienteEvent>().GetMongoDbContext(mongoFake);
            var pacienteRepository = new PacienteRepository(null, mongoDbContextoMock.Object);
            return new ApplicationServicePaciente(new Mock<IPlanoAlimentarRepository>().Object, pacienteRepository, null, null, null);
        }

        private ITokenService GetTokenServiceMock()
        {
            var tokenServiceMock = new Mock<ITokenService>();

            var tokenDTO = new TokenDTO()
            {
                Id = NutricionistaEntityFake.Id
            };

            tokenServiceMock.Setup(x => x.GetInformacoesDoToken(It.IsAny<string>())).Returns(tokenDTO);
            return tokenServiceMock.Object;
        }

        private static IEnumerable<object[]> GetVerificacoesInvalidosPacientes()
        {
            yield return new object[] { NutricionistaEventFake.GetFakePacientesNull() };
            yield return new object[] { NutricionistaEventFake.GetFakeNull() };
            yield return new object[] { NutricionistaEventFake.GetFake() };
        }
    }
}
