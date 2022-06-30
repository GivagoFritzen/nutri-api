using Application.Services;
using Application.ViewModel.Login;
using ApplicationTest.ViewModel.Login;
using CrossCutting.Message.Exceptions;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using Domain.Services;
using DomainTest.DTO;
using DomainTest.Event;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
        public async Task Senha_Divergentes()
        {
            nutricionistaRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(Task.FromResult(NutricionistaEventFake.GetFake()));

            await Assert.ThrowsExceptionAsync<UnauthorizedAccessException>(() =>
                applicationService.Login(LoginNutricionistaViewModelFake.GetFake())
            );
        }

        [TestMethod]
        public async Task Login_Invalido()
        {
            var retorno = await applicationService.Login(LoginNutricionistaViewModelFake.GetSenhaInvalido());
            retorno.Errors.Should().NotBeNullOrEmpty();
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

        [TestMethod]
        public void Refresh_Invalido()
        {
            var result = applicationService.Refresh(new LoginTokenViewModel());
            result.Errors.Should().Contain(ExceptionsMessages.RefreshTokenInvalido);
        }

        [TestMethod]
        public void Refresh_Valido()
        {
            var loginTokenDTO = LoginTokenDTOFake.GetFake();

            var tokenServiceMock = new Mock<ITokenService>();
            tokenServiceMock.Setup(x => x.GetPrincipalFromToken(It.IsAny<string>())).Returns(new ClaimsPrincipal());
            tokenServiceMock.Setup(x => x.GetLoginToken(It.IsAny<IEnumerable<Claim>>())).Returns(loginTokenDTO);

            tokenRepositoryMock.Setup(x => x.VerificarRefreshToken(It.IsAny<string>())).Returns(Task.FromResult(true));

            var applicationServiceLogin = new ApplicationServiceLogin(
                tokenServiceMock.Object,
                new SecurityService(),
                tokenRepositoryMock.Object,
                nutricionistaRepositoryMock.Object);

            var result = (LoginTokenViewModel)applicationServiceLogin.Refresh(new LoginTokenViewModel()).Body;

            result.Token.Should().Be(loginTokenDTO.Token);
            result.RefreshToken.Should().Be(loginTokenDTO.RefreshToken);
        }
    }
}
