using Domain.Entity;
using System;

namespace DomainTest.Entity
{
    public static class AdminEntityFake
    {
        public static AdminsEntity GetAdminEntitySemIdFake(
            string senha = "senha",
            string email = "email")
        {
            return new AdminsEntity()
            {
                Senha = senha,
                Email = email
            };
        }

        public static AdminsEntity GetAdminEntitySemSenhaFake(
            string email = "email")
        {
            return new AdminsEntity()
            {
                Id = Guid.NewGuid(),
                Email = email
            };
        }
    }
}
