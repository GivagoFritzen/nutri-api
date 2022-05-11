using Core.Interfaces.Services;
using CrossCutting.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class TokenService : ITokenService
    {
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        public TokenService() { }

        public string GenerateToken(string email, Permissoes permissao)
        {
            var key = Encoding.ASCII.GetBytes(AuthenticationSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Role, permissao.ToString())
                }),

                Expires = AuthenticationSettings.ExpireTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), AuthenticationSettings.Algorithm)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
