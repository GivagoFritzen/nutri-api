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

            var claimName = new Claim(ClaimTypes.Name, name);
            var claimEmail = new Claim(ClaimTypes.Email, email);
            var claimPrimaryId = new Claim(ClaimTypes.PrimarySid, id.ToString());
            var claimRole = new Claim(ClaimTypes.Role, role.ToString());

            var claims = new List<Claim>() {
                claimName,
                claimEmail,
                claimPrimaryId,
                claimRole
            };

            var actual = tokenService.GetLoginToken(claims);
            var claimsFromToken = tokenService.GetClaimsFromToken(actual.Token);

            Assert.AreEqual(name, GetClaimByValue(claimsFromToken, claimName.Value));
            Assert.AreEqual(role.ToString(), GetClaimByValue(claimsFromToken, claimRole.Value));
            Assert.AreEqual(id.ToString(), GetClaimByValue(claimsFromToken, claimPrimaryId.Value));
            Assert.AreEqual(email, GetClaimByValue(claimsFromToken, claimEmail.Value));
        }

        private string GetClaimByValue(IEnumerable<Claim> claims, string value)
        {
            return claims.FirstOrDefault(c => c.Value == value).Value.ToString();
        }
    }
}
