using Domain.Entity;
using Domain.Event;

namespace Core.Interfaces.Services
{
    public interface IAdminService : IServiceBase<AdminEntity, AdminEvent>
    {
    }
}