using Application.Services;
using ApplicationTest.ViewModel.Login;
using Domain.Interface.Repository;
using Domain.Services;
using DomainTest.Event;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace ApplicationTest.Services
{
    [TestClass]
    public class ApplicationServiceLoginTest
    {
        private ApplicationServiceLogin applicationService;
        private Mock<ITokenRepository> tokenRepositoryMock = new Mock<ITokenRepository>();
        private Mock<INutricionistaRepository> nutricionistaRepositoryMock = new Mock<INutricionistaRepository>();

        [TestInitialize]
        public void Initialize()
        {
            applicationService = new ApplicationServiceLogin(
                new TokenService(),
                new SecurityService(),
                tokenRepositoryMock.Object,
                nutricionistaRepositoryMock.Object);
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
            nutricionistaRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(Task.FromResult(NutricionistaEventFake.GetFake()));

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

            nutricionistaRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(Task.FromResult(nutricionista));

            var retorno = await applicationService.Login(LoginNutricionistaViewModelFake.GetFake());
            retorno.Errors.Should().BeNull();
        }
    }
}
