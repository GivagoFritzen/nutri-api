using Domain.Entity;
using System;

namespace DomainTest.Entity
{
    public static class AdminEntityFake
    {
        public static AdminEntity GetAdminEntitySemIdFake(
            string senha = "senha",
            string email = "email")
        {
            return new AdminEntity()
            {
                Senha = senha,
                Email = email
            };
        }

        public static AdminEntity GetAdminEntitySemSenhaFake(
            string email = "email")
        {
            return new AdminEntity()
            {
                Id = Guid.NewGuid(),
                Email = email
            };
        }
    }
}
