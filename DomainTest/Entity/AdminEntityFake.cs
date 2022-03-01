using Domain.Entity;
using System;

namespace DomainTest.Entity
{
    public static class AdminEntityFake
    {
        public static AdminsEntity GetAdminEntitySemIdFake(
            string senha = "senha",
            string email = "teste@provedor.com")
        {
            return new AdminsEntity()
            {
                Senha = senha,
                Email = email
            };
        }

        public static AdminsEntity GetAdminEntitySemSenhaFake(
            string email = "teste@provedor.com")
        {
            return new AdminsEntity()
            {
                Id = Guid.NewGuid(),
                Email = email
            };
        }
    }
}
