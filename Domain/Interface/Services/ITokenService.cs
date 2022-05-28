using Domain.DTO.Token;
using System.Collections.Generic;
using System.Security.Claims;

namespace Domain.Interface.Services
{
    public interface ITokenService
    {
        LoginTokenDTO GetLoginToken(IEnumerable<Claim> claims);
        ClaimsPrincipal GetPrincipalFromToken(string token);
        TokenDTO GetInformacoesDoToken(string token);
    }
}