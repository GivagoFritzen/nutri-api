namespace Domain.Interface.Services
{
    public interface ISecurityService
    {
        bool ComparePassword(string password, string confirmPassword);
        bool VerifyPassword(string password, string passwordHash);
        string EncryptPassword(string password);
    }
}
