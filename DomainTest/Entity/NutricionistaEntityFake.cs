using Domain.Entity;
using System;
using System.Collections.Generic;

namespace DomainTest.Entity
{
    public static class NutricionistaEntityFake
    {
        public static Guid Id = Guid.Parse("f022116a-a01f-4b30-b3aa-8c7e3d6b21d8");

        public static NutricionistaEntity GetFake()
        {
            return new NutricionistaEntity()
            {
                Senha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                PacientesIds = new List<Guid>()
            };
        }
    }
}
