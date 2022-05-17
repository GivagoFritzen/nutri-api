using CrossCutting.Authentication;
using System;

namespace Core.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(string name, string email, Guid id, Permissoes permissao);
    }
}