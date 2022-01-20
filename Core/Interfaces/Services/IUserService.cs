using System;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<bool> VerificarEmailExiste(string email);
        Task<bool> VerificarEmailExiste(string email, Guid currentId);
    }
}