using Application.Services;
using Application.ViewModel.Admin;
using ApplicationTest.ViewModel.Admin;
using Core.Interfaces.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using System.Threading.Tasks;

namespace ApplicationTest.Services
{
    [TestClass]
    public class ApplicationServiceAdminTest
    {
        private Mock<IAdminService> adminServiceMock = new Mock<IAdminService>();
        private Mock<IUserService> userServiceMock = new Mock<IUserService>();
        private Mock<IMessagingService> messagingServiceMock = new Mock<IMessagingService>();

        [TestMethod]
        public async Task Add_Invalido()
        {
            var applicationService = new ApplicationServiceAdmin(
                adminServiceMock.Object,
                new SecurityService(),
                userServiceMock.Object,
                messagingServiceMock.Object);

            var retorno = await applicationService.Add(AdminViewModelFake.GetEmailRequisitosInvalidosFake());
            retorno.Errors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Add_Valido()
        {
            var securityService = new SecurityService();
            var applicationService = new ApplicationServiceAdmin(
                adminServiceMock.Object,
                securityService,
                userServiceMock.Object,
                messagingServiceMock.Object);

            var model = AdminViewModelFake.GetFake();
            var retorno = (await applicationService.Add(model)).Body as AdminAdicionarViewModel;

            Assert.AreEqual(model.Email, retorno.Email);
            Assert.IsTrue(securityService.VerifyPassword(model.Senha, retorno.Senha));
        }
    }
}
