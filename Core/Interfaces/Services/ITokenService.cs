using CrossCutting.Authentication;

namespace Core.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(string email, Permissoes Permissao);
    }
}