using Domain.Interface.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;

namespace Domain.ServicesTest
{
    [TestClass]
    public class SecurityServiceTest
    {
        ISecurityService securityService;

        [TestInitialize]
        public void Initialize()
        {
            securityService = new SecurityService();
        }

        [TestMethod]
        public void Compare_Password_Equal()
        {
            var password = "password";
            var actual = securityService.ComparePassword(password, password);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Compare_Password_Different()
        {
            var actual = securityService.ComparePassword("password", "");

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Compare_Password_Invalid()
        {
            var actual = securityService.ComparePassword("", null);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Verify_Password_Crypt_Valid()
        {
            var password = "password";
            var passwordEncrypted = securityService.EncryptPassword(password);
            var actual = securityService.VerifyPassword(password, passwordEncrypted);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Verify_PasswordCryptInvalid()
        {
            var password = "password";
            var actual = securityService.VerifyPassword(password, password);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Encrypt_Password_Valid()
        {
            var securityService = new SecurityService();

            var password = "password";
            var actual = securityService.EncryptPassword(password);

            Assert.AreNotEqual(password, actual);
        }

        [TestMethod]
        public void Encrypt_Password_Invalid()
        {
            Assert.ThrowsException<FormatException>(() => securityService.EncryptPassword(null));
        }
    }
}
