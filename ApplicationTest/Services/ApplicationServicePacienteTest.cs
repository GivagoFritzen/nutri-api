using Application.Interfaces;
using Application.Services;
using Application.ViewModel;
using Application.ViewModel.Medidas;
using Application.ViewModel.Nutricionistas;
using Application.ViewModel.Pacientes;
using ApplicationTest.ViewModel.Medida;
using ApplicationTest.ViewModel.Nutricionista;
using ApplicationTest.ViewModel.Paciente;
using CrossCutting.Message.Validation;
using CrossCuttingTest;
using Domain.DTO.Token;
using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using Domain.Repository;
using DomainTest.Entity;
using DomainTest.Event;
using FluentAssertions;
using Microsoft.Extensions.Primitives;
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
                new Mock<IApplicationServiceNutricionista>().Object,
                new Mock<IPlanoAlimentarRepository>().Object,
                new Mock<IPacienteRepository>().Object,
                null,
                new Mock<IMessagingService>().Object,
                new Mock<IUserRepository>().Object,
                GetTokenServiceMock());
        }

        [TestMethod]
        public async Task Add_Invalido()
        {
            var retorno = await applicationService.Add(PacienteAdicionarViewModelFake.GetNomeVazioFake(), StringValues.Empty);
            retorno.Should().BeOfType<ErrorViewModel>();
        }

        [TestMethod]
        public async Task Add_Valido()
        {
            var model = PacienteAdicionarViewModelFake.GetFake();
            var retorno = (await applicationService.Add(model, StringValues.Empty)) as PacienteViewModel;

            retorno.Should().BeEquivalentTo(model);
        }

        [TestMethod]
        public async Task Get_By_Id_Inexistente()
        {
            var mongoFake = new MongoFake<PacienteEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<PacienteEvent>().GetMongoDbContext(mongoFake);
            var pacienteRepository = new PacienteRepository(null, mongoDbContextoMock.Object);

            var applicationServicePaciente = new ApplicationServicePaciente(
                null, new Mock<IPlanoAlimentarRepository>().Object, pacienteRepository, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

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
                null, new Mock<IPlanoAlimentarRepository>().Object, pacienteRepository, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var retorno = await applicationServicePaciente.GetById(PacienteEntityFake.Id);
            retorno.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Remove()
        {
            var pacienteRepositoryMock = new Mock<IPacienteRepository>();
            var messagingServiceMock = new Mock<IMessagingService>();
            var applicationServiceNutricionista = new Mock<IApplicationServiceNutricionista>();
            applicationServiceNutricionista.Setup(x => x.RemoveById(It.IsAny<Guid>()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                applicationServiceNutricionista.Object, new Mock<IPlanoAlimentarRepository>().Object, pacienteRepositoryMock.Object,
                null, messagingServiceMock.Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            await applicationServicePaciente.RemoveById(Guid.NewGuid());
            pacienteRepositoryMock.Verify(mock => mock.RemoveById(It.IsAny<Guid>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<UserEvent>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<PacienteEvent>()), Times.Once());
        }

        [TestMethod]
        public async Task Update_Invalido()
        {
            var retorno = await applicationService.Update(PacienteAtualizarViewModelFake.GetNomeVazioFake(), StringValues.Empty);
            retorno.Should().BeOfType<ErrorViewModel>();
        }

        [TestMethod]
        public async Task Update_Valido()
        {
            var model = PacienteAtualizarViewModelFake.GetFake();
            var retorno = await applicationService.Update(model, StringValues.Empty);

            retorno.Should()
                .BeEquivalentTo(model, options =>
                    options.Excluding(_ => _.Id)
                );
        }

        [TestMethod]
        public async Task Get_All_Planos_Alimentares_Vazio()
        {
            var applicationServiceNutricionistaMock = new Mock<IApplicationServiceNutricionista>();
            applicationServiceNutricionistaMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(NutricionistaViewModelFake.GetFakeComPacientes()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                applicationServiceNutricionistaMock.Object, new Mock<IPlanoAlimentarRepository>().Object, GetPacienteRepository().Result, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var result = await applicationServicePaciente.GetAllPlanosAlimenares(new Guid());
            result.Should().BeEmpty();
        }

        [TestMethod]
        public async Task Get_All_Planos_Alimentares_Com_Plano()
        {
            var applicationServiceNutricionistaMock = new Mock<IApplicationServiceNutricionista>();
            applicationServiceNutricionistaMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(NutricionistaViewModelFake.GetFakeComPacientes()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                applicationServiceNutricionistaMock.Object, new Mock<IPlanoAlimentarRepository>().Object, GetPacienteRepository().Result, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var result = await applicationServicePaciente.GetAllPlanosAlimenares(PacienteEntityFake.Id);
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public async Task Adicionar_Plano_Alimentar_Invalido()
        {
            var retorno = await applicationService.AdicionarPlanoAlimentar(PacientePlanoAlimentarViewModelFake.GetFakeRefeicaoNull());
            retorno.Should().BeOfType<ErrorViewModel>();
        }

        [TestMethod]
        public async Task Adicionar_Plano_Alimentar_Valido()
        {
            var messagingServiceMock = new Mock<IMessagingService>();
            var pacienteRepositoryMock = new Mock<IPacienteRepository>();
            pacienteRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(PacienteEventFake.GetPacienteEventFake()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                null, new Mock<IPlanoAlimentarRepository>().Object, pacienteRepositoryMock.Object,
                null, messagingServiceMock.Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var model = PacientePlanoAlimentarViewModelFake.GetFake();
            var retorno = await applicationServicePaciente.AdicionarPlanoAlimentar(model);

            retorno.Should().BeEquivalentTo(model);

            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<PacienteEvent>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<UserEvent>()), Times.Once());
            pacienteRepositoryMock.Verify(mock => mock.Update(It.IsAny<PacienteEntity>()), Times.Once());
        }

        [TestMethod]
        public void Atualizar_Plano_Alimentar_Invalido()
        {
            var retorno = applicationService.AtualizarPlanoAlimentar(PacienteAtualizarPlanoAlimentarViewModelFake.GetFake());
            retorno.Should().BeOfType<ErrorViewModel>();
        }

        [TestMethod]
        public void Atualizar_Plano_Alimentar_Valido()
        {
            var viewModel = PacienteAtualizarPlanoAlimentarViewModelFake.GetFake();

            var planoAlimentarRepositoryMock = new Mock<IPlanoAlimentarRepository>();
            planoAlimentarRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(PlanoAlimentarEntityFake.GetFake()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                null, planoAlimentarRepositoryMock.Object, new Mock<IPacienteRepository>().Object, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var retorno = applicationServicePaciente.AtualizarPlanoAlimentar(viewModel);

            planoAlimentarRepositoryMock.Verify(mock => mock.Update(It.IsAny<PlanoAlimentarEntity>()), Times.Once());
        }

        [DataTestMethod]
        [DynamicData(nameof(GetVerificacoesInvalidosPacientes), DynamicDataSourceType.Method)]
        public async Task Get_Nutri_Sem_Pacientes(NutricionistaViewModel nutricionista)
        {
            var applicationServiceNutricionista = new Mock<IApplicationServiceNutricionista>();
            applicationServiceNutricionista.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(nutricionista));

            var applicationServicePaciente = new ApplicationServicePaciente(
                applicationServiceNutricionista.Object, new Mock<IPlanoAlimentarRepository>().Object, null, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var result = await applicationServicePaciente.GetPacientes(StringValues.Empty);
            result.Should().BeEmpty();
        }

        [TestMethod]
        public async Task Get_Nutri_Com_Pacientes()
        {
            var applicationServiceNutricionistaMock = new Mock<IApplicationServiceNutricionista>();
            applicationServiceNutricionistaMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(NutricionistaViewModelFake.GetFakeComPacientes()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                applicationServiceNutricionistaMock.Object, new Mock<IPlanoAlimentarRepository>().Object, GetPacienteRepository().Result, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var result = await applicationServicePaciente.GetPacientes(StringValues.Empty);
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public async Task Get_All_Medidas_Sem_Medidas()
        {
            var applicationServiceNutricionistaMock = new Mock<IApplicationServiceNutricionista>();
            applicationServiceNutricionistaMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(NutricionistaViewModelFake.GetFakeComPacientes()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                applicationServiceNutricionistaMock.Object, new Mock<IPlanoAlimentarRepository>().Object, GetPacienteRepository().Result, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var result = await applicationServicePaciente.GetAllMedidas(new Guid());
            result.Should().BeEmpty();
        }

        [TestMethod]
        public async Task Get_All_Medidas_Com_Medidas()
        {
            var applicationServiceNutricionistaMock = new Mock<IApplicationServiceNutricionista>();
            applicationServiceNutricionistaMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(NutricionistaViewModelFake.GetFakeComPacientes()));

            var applicationServicePaciente = new ApplicationServicePaciente(
                applicationServiceNutricionistaMock.Object, new Mock<IPlanoAlimentarRepository>().Object, GetPacienteRepository().Result, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var result = await applicationServicePaciente.GetAllMedidas(PacienteEntityFake.Id);
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public async Task Adicionar_Medidas_Usuario_Nao_Encontrado()
        {
            var applicationServicePaciente = new ApplicationServicePaciente(
                null, new Mock<IPlanoAlimentarRepository>().Object, GetPacienteRepository().Result, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(() =>
                applicationServicePaciente.AdicionarMedidas(MedidaAdicionarViewModelFake.GetFake())
            );
        }

        [TestMethod]
        public async Task Adicionar_Medidas_Invalidas()
        {
            var applicationServicePaciente = new ApplicationServicePaciente(
                null, new Mock<IPlanoAlimentarRepository>().Object, new Mock<IPacienteRepository>().Object, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var result = await applicationServicePaciente.AdicionarMedidas(new MedidaAdicionarViewModel()
            {
                PacienteId = PacienteEventFake.Id,
                Medida = new MedidaViewModel()
            }) as ErrorViewModel;

            result.Errors.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Descricao"));
            result.Errors.Should().Contain("PesoAtual - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            result.Errors.Should().Contain("PesoIdeal - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            result.Errors.Should().Contain("Altura - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
        }

        [TestMethod]
        public async Task Adicionar_Medidas()
        {
            var paciente = PacienteEventFake.GetPacienteEventFake();
            paciente.Medidas = null;

            var pacienteRepositoryMock = new Mock<IPacienteRepository>();
            pacienteRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(paciente));

            var messagingServiceMock = new Mock<IMessagingService>();
            var medidaRepository = new Mock<IMedidaRepository>();

            var applicationServicePaciente = new ApplicationServicePaciente(
                null, new Mock<IPlanoAlimentarRepository>().Object, pacienteRepositoryMock.Object, medidaRepository.Object,
                messagingServiceMock.Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var result = await applicationServicePaciente.AdicionarMedidas(new MedidaAdicionarViewModel()
            {
                PacienteId = PacienteEventFake.Id,
                Medida = MedidaViewModelFake.GetFake()
            }) as MedidaAdicionarViewModel;

            result.Should().BeEquivalentTo(MedidaAdicionarViewModelFake.GetFake(),
                options => options.Excluding(_ => _.PacienteId)
                .Excluding(_ => _.Medida.Data));

            medidaRepository.Verify(mock => mock.AddAsync(It.IsAny<MedidaEntity>()), Times.Once());
            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<PacienteEvent>()), Times.Once());
        }

        [TestMethod]
        public async Task Atualizar_Medidas_Usuario_Nao_Encontrado()
        {
            var applicationServicePaciente = new ApplicationServicePaciente(
                null, new Mock<IPlanoAlimentarRepository>().Object, GetPacienteRepository().Result, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(() =>
                applicationServicePaciente.AtualizarMedidas(MedidaAtualizarViewModelFake.GetFake())
            );
        }

        [TestMethod]
        public async Task Atualizar_Medidas_Inexistente()
        {
            var applicationServicePaciente = new ApplicationServicePaciente(
                null, new Mock<IPlanoAlimentarRepository>().Object, new Mock<IPacienteRepository>().Object, null,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            await Assert.ThrowsExceptionAsync<NullReferenceException>(() =>
                applicationServicePaciente.AtualizarMedidas(new MedidaAtualizarViewModel()
                {
                    PacienteId = PacienteEventFake.Id,
                    MedidaId = Guid.NewGuid(),
                    Medida = new MedidaViewModel()
                })
            );
        }

        [TestMethod]
        public async Task Atualizar_Medidas_Invalidas()
        {
            var applicationServicePaciente = new ApplicationServicePaciente(
                null, new Mock<IPlanoAlimentarRepository>().Object, new Mock<IPacienteRepository>().Object, new Mock<IMedidaRepository>().Object,
                new Mock<IMessagingService>().Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var result = await applicationServicePaciente.AtualizarMedidas(new MedidaAtualizarViewModel()
            {
                PacienteId = PacienteEventFake.Id,
                MedidaId = Guid.NewGuid(),
                Medida = new MedidaViewModel()
            }) as ErrorViewModel;

            result.Errors.Should().Contain(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Descricao"));
            result.Errors.Should().Contain("PesoAtual - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            result.Errors.Should().Contain("PesoIdeal - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
            result.Errors.Should().Contain("Altura - " + string.Format(GenericValidationMessages.ValorMinimo, "0"));
        }

        [TestMethod]
        public async Task Atualizar_Medidas()
        {
            var paciente = PacienteEventFake.GetPacienteEventFake();
            paciente.Medidas = null;

            var pacienteRepositoryMock = new Mock<IPacienteRepository>();
            pacienteRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(paciente));

            var medidaRepositoryMock = new Mock<IMedidaRepository>();
            medidaRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(MedidaEntityFake.GetFake()));
            medidaRepositoryMock.Setup(x => x.GetByIdWithCircunferencia(It.IsAny<Guid>())).Returns(Task.FromResult(MedidaEntityFake.GetFake()));

            var messagingServiceMock = new Mock<IMessagingService>();
            var applicationServicePaciente = new ApplicationServicePaciente(
                null, new Mock<IPlanoAlimentarRepository>().Object, pacienteRepositoryMock.Object, medidaRepositoryMock.Object,
                messagingServiceMock.Object, new Mock<IUserRepository>().Object, GetTokenServiceMock());

            var medida = new MedidaAtualizarViewModel()
            {
                PacienteId = PacienteEventFake.Id,
                MedidaId = Guid.NewGuid(),
                Medida = MedidaViewModelFake.GetFake()
            };

            var result = (await applicationServicePaciente.AtualizarMedidas(medida)) as MedidaAtualizarViewModel;

            result.Should().BeEquivalentTo(medida);

            messagingServiceMock.Verify(mock => mock.Publish(It.IsAny<PacienteEvent>()), Times.Once());
            pacienteRepositoryMock.Verify(mock => mock.GetById(It.IsAny<Guid>()), Times.Exactly(2));
            medidaRepositoryMock.Verify(mock => mock.GetById(It.IsAny<Guid>()), Times.Exactly(1));
            medidaRepositoryMock.Verify(mock => mock.GetByIdWithCircunferencia(It.IsAny<Guid>()), Times.Exactly(1));
            medidaRepositoryMock.Verify(mock => mock.Update(It.IsAny<MedidaEntity>()), Times.Once());
        }

        private static IEnumerable<object[]> GetVerificacoesInvalidosPacientes()
        {
            yield return new object[] { NutricionistaViewModelFake.GetFakePacientesNull() };
            yield return new object[] { NutricionistaViewModelFake.GetFakeNull() };
            yield return new object[] { NutricionistaViewModelFake.GetFake() };
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

        private async Task<PacienteRepository> GetPacienteRepository()
        {
            var mongoFake = new MongoFake<PacienteEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<PacienteEvent>().GetMongoDbContext(mongoFake);
            return new PacienteRepository(null, mongoDbContextoMock.Object);
        }
    }
}
