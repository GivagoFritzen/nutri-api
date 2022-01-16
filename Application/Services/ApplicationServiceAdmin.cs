﻿using Application.Commands.Admin;
using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Application.ViewModel.Admin;
using Core.Interfaces.Services;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceAdmin : IApplicationServiceAdmin
    {
        private readonly IAdminService adminService;
        private readonly ISecurityService securityService;

        public ApplicationServiceAdmin(IAdminService adminService, ISecurityService securityService)
        {
            this.adminService = adminService;
            this.securityService = securityService;
        }

        public async Task<ResponseView> Add(AdminAdicionarViewModel adminAdicionarViewModel)
        {
            var command = new AdminAdicionarCommand(adminAdicionarViewModel);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var admin = adminAdicionarViewModel.ToEntity();
            var passwordEncripted = securityService.EncryptPassword(admin.Senha);
            admin.Senha = passwordEncripted;
            await adminService.AddAsync(admin);

            return new ResponseView(admin.ToViewModel());
        }
    }
}