using Domain.Interface.Services;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        /*
        [TestMethod]
        public void Gerar_Token()
        {
            var name = "name";
            var id = Guid.NewGuid();
            var email = "email";
            var role = Permissoes.Nutricionista;

            var actual = tokenService.GenerateToken(name, email, id, role);
            var decode = new JwtSecurityTokenHandler().ReadToken(actual);

            Assert.AreEqual(name, ((JwtSecurityToken)decode).Payload["unique_name"].ToString());
            Assert.AreEqual(role.ToString(), ((JwtSecurityToken)decode).Payload["role"].ToString());
            Assert.AreEqual(id.ToString(), ((JwtSecurityToken)decode).Payload["primarysid"].ToString());
            Assert.AreEqual(email, ((JwtSecurityToken)decode).Payload["email"].ToString());
        }
        */
    }
}
