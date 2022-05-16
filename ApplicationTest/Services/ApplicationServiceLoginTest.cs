using Application.Services;
using ApplicationTest.ViewModel.Login;
using Core.Interfaces.Services;
using DomainTest.Event;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using System;
using System.Threading.Tasks;

namespace ApplicationTest.Services
{
    [TestClass]
    public class ApplicationServiceLoginTest
    {
        private ApplicationServiceLogin applicationService;
        private Mock<INutricionistaService> nutricionistaServiceMock = new Mock<INutricionistaService>();

        [TestInitialize]
        public void Initialize()
        {
            applicationService = new ApplicationServiceLogin(
                new TokenService(),
                nutricionistaServiceMock.Object,
                new SecurityService());
        }

        [TestMethod]
        public async Task Email_Inexistente()
        {
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
                applicationService.Login(LoginNutricionistaViewModelFake.GetFake())
            );
        }

        [TestMethod]
        public async Task Senha_Divergentes()
        {
            nutricionistaServiceMock.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(Task.FromResult(NutricionistaEventFake.GetFake()));

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
                applicationService.Login(LoginNutricionistaViewModelFake.GetFake())
            );
        }

        [TestMethod]
        public async Task Login_Valido()
        {
            var nutricionista = NutricionistaEventFake.GetFake();
            var securityService = new SecurityService();
            nutricionista.Senha = securityService.EncryptPassword(nutricionista.Senha);

            nutricionistaServiceMock.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(Task.FromResult(nutricionista));

            var retorno = await applicationService.Login(LoginNutricionistaViewModelFake.GetFake());
            retorno.Errors.Should().BeNull();
        }
    }
}
