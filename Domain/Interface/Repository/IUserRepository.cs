using System;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IUserRepository
    {
        Task<bool> VerificarEmailExiste(string email);
        Task<bool> VerificarEmailExiste(string email, string type);
        Task<bool> VerificarEmailExiste(string email, Guid currentId);
    }
}