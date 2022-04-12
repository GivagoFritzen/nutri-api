using Application.Services;
using Application.ViewModel.Nutricionistas;
using ApplicationTest.ViewModel.Nutricionista;
using Core.Interfaces.Services;
using CrossCuttingTest;
using Domain.Event;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using System;
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
                new Mock<INutricionistaService>().Object,
                new Mock<IMessagingService>().Object,
                new SecurityService(),
                new Mock<IUserService>().Object,
                new Mock<IPacienteService>().Object);
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
        public async Task Get_By_Id_Inexistente()
        {
            var mongoFake = new MongoFake<NutricionistaEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<NutricionistaEvent>().GetMongoDbContext(mongoFake);
            var nutricionistaService = new NutricionistaService(null, mongoDbContextoMock.Object);

            var applicationServiceNutricionista = new ApplicationServiceNutricionista(
                nutricionistaService,
                new Mock<IMessagingService>().Object,
                new SecurityService(),
                new Mock<IUserService>().Object,
                new Mock<IPacienteService>().Object);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
                applicationServiceNutricionista.GetById(Guid.NewGuid())
            );
        }

        [TestMethod]
        public async Task Get_By_Id_Existente()
        {
            var mongoFake = new MongoFake<NutricionistaEvent>();
            var mongoDbContextoMock = await new MongoDbContextFake<NutricionistaEvent>().GetMongoDbContext(mongoFake);
            var nutricionistaService = new NutricionistaService(null, mongoDbContextoMock.Object);

            var applicationServiceNutricionista = new ApplicationServiceNutricionista(
                nutricionistaService,
                new Mock<IMessagingService>().Object,
                new SecurityService(),
                new Mock<IUserService>().Object,
                new Mock<IPacienteService>().Object);

            var retorno = await applicationServiceNutricionista.GetById(NutricionistaEntityFake.Id);
            retorno.Should().NotBeNull();
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
    }
}
