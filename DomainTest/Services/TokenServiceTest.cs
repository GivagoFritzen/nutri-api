using CrossCutting.Authentication;
using Domain.Interface.Services;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Domain.ServicesTest
{
    [TestClass]
    public class TokenServiceTest
    {
        private ITokenService tokenService;

        [TestInitialize]
        public void Initialize()
        {
            tokenService = new TokenService();
        }

        [TestMethod]
        public void Gerar_Token()
        {
            var name = "name";
            var id = Guid.NewGuid();
            var email = "email";
            var role = Permissoes.Nutricionista;

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.PrimarySid, id.ToString()),
                new Claim(ClaimTypes.Role, role.ToString())
            };

            var actual = tokenService.GetLoginToken(claims);
            var principal = tokenService.GetPrincipalFromToken(actual.Token);

            Assert.AreEqual(name, GetClaim(principal, ClaimTypes.Name));
            Assert.AreEqual(role.ToString(), GetClaim(principal, ClaimTypes.Role));
            Assert.AreEqual(id.ToString(), GetClaim(principal, ClaimTypes.PrimarySid));
            Assert.AreEqual(email, GetClaim(principal, ClaimTypes.Email));
        }

        private string GetClaim(ClaimsPrincipal principal, string type)
        {
            return principal.Claims.FirstOrDefault(c => c.Type == type).Value.ToString();
        }
    }
}
