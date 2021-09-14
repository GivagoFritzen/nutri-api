using Core.Interfaces.Services;

namespace Services
{
    public class SecurityService : ISecurityService
    {
        public bool ComparePassword(string password, string confirmPassword)
        {
            return password.Trim().Equals(confirmPassword.Trim());
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        public string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
