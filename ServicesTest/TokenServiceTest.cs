using Core.Interfaces.Services;
using CrossCutting.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.IdentityModel.Tokens.Jwt;

namespace ServicesTest
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
        public void Teste()
        {
            var email = "email";
            var role = Permissoes.Nutricionista;
            var actual = tokenService.GenerateToken(email, role);

            var decode = new JwtSecurityTokenHandler().ReadToken(actual);

            Assert.AreEqual(email, ((JwtSecurityToken)decode).Payload["unique_name"].ToString());
            Assert.AreEqual(role.ToString(), ((JwtSecurityToken)decode).Payload["role"].ToString());
        }
    }
}
