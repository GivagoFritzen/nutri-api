using Application.Commands.Admin;
using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Application.ViewModel.Admin;
using Core.Interfaces.Services;
using Domain.Event;
using Services;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceAdmin : IApplicationServiceAdmin
    {
        private readonly IAdminService adminService;
        private readonly IUserService userService;
        private readonly ISecurityService securityService;
        private readonly IMessagingService messagingService;

        public ApplicationServiceAdmin(
            IAdminService adminService,
            ISecurityService securityService,
            IUserService userService,
            IMessagingService messagingService)
        {
            this.adminService = adminService;
            this.securityService = securityService;
            this.userService = userService;
            this.messagingService = messagingService;
        }

        public async Task<ResponseView> Add(AdminAdicionarViewModel adminAdicionarViewModel)
        {
            var command = new AdminAdicionarCommand(adminAdicionarViewModel, userService);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var admin = adminAdicionarViewModel.ToEntity();
            var passwordEncripted = securityService.EncryptPassword(admin.Senha);
            admin.Senha = passwordEncripted;

            await adminService.AddAsync(admin);
            messagingService.Publish(admin.ToAdminEvent());
            messagingService.Publish(new UserEvent(admin.Id, admin.Email));

            return new ResponseView(admin.ToViewModel());
        }
    }
}
