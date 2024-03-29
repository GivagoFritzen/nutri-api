﻿using Domain.Interface.Services;
using CrossCutting.Authentication;
using Domain.Entity.Token;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class TokenService : ITokenService
    {
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        public TokenService() { }

        public LoginTokenEntity GetLoginToken(IEnumerable<Claim> claims)
        {
            return new LoginTokenEntity()
            {
                Token = GenerateToken(claims),
                RefreshToken = GenerateRefreshToken()
            };
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticationSettings.Secret)),
                ValidateLifetime = false
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public TokenEntity GetInformacoesDoToken(string token)
        {
            token = token.Replace("Bearer ", "");
            var decode = (JwtSecurityToken)new JwtSecurityTokenHandler().ReadToken(token);
            Enum.TryParse("Active", out Permissoes role);

            return new TokenEntity()
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
                Expires = AuthenticationSettings.ExpireTime,
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
