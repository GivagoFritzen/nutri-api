using Core.Interfaces.Services;
using Domain.Entity;
using Domain.Event;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Interfaces.Mongo;
using Services.Base;

namespace Services
{
    public class AdminService : ServiceBase<AdminEntity, AdminEvent>, IAdminService
    {
        public AdminService(IRepositoryBase<AdminEntity> repositoryAdmin, IMongoDbContext mongoDbContext)
            : base(repositoryAdmin, mongoDbContext)
        {
            repository = repositoryAdmin;
        }
    }
}