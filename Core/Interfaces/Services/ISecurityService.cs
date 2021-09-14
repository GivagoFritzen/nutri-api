using Domain.Entity;

namespace Core.Interfaces.Services
{
    public interface ISecurityService
    {
        bool ComparePassword(string password, string confirmPassword);
        bool VerifyPassword(string password, string passwordHash);
        string EncryptPassword(string password);
    }
}
