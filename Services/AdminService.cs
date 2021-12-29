using Core.Interfaces.Services;
using Domain.Entity;
using Infrastructure.Data.Interfaces;
using Services.Base;

namespace Services
{
    public class AdminService : ServiceBase<AdminEntity>, IAdminService
    {
        public AdminService(IRepositoryBase<AdminEntity> repositoryAdmin)
            : base(repositoryAdmin)
        {
            repository = repositoryAdmin;
        }
    }
}