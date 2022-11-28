using CrossCutting.Authentication;
using Domain.DTO.Token;
using Domain.Interface.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Services
{
    public class TokenService : ITokenService
    {
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        public TokenService() { }

        public LoginTokenDTO GetLoginToken(IEnumerable<Claim> claims)
        {
            return new LoginTokenDTO()
            {
                Token = GenerateToken(claims),
                RefreshToken = GenerateRefreshToken()
            };
        }

        public List<Claim> GetClaimsFromToken(string token)
        {
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                securityToken.ValidTo < DateTime.UtcNow ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return securityToken.Claims.ToList();
        }

        public TokenDTO GetInformacoesDoToken(string token)
        {
            token = token.Replace("Bearer ", "");
            var decode = (JwtSecurityToken)tokenHandler.ReadToken(token);
            Enum.TryParse("Active", out Permissoes role);

            return new TokenDTO()
            {
                Name = decode.Payload["unique_name"].ToString(),
                Email = decode.Payload["email"].ToString(),
                Id = Guid.Parse(decode.Payload["primarysid"].ToString()),
                Role = role
            };
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = Encoding.ASCII.GetBytes(AuthenticationSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(AuthenticationSettings.ExpireTime.TotalSeconds / 2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), AuthenticationSettings.Algorithm)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
