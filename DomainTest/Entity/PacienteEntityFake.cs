using Domain.Entity;
using System;
using System.Collections.Generic;

namespace DomainTest.Entity
{
    public static class PacienteEntityFake
    {
        public static Guid Id = Guid.Parse("9714d9be-4877-4081-84d7-b6acdb3ed483");

        public static PacienteEntity GetPacienteEntityFake()
        {
            return new PacienteEntity()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medidas = new List<MedidaEntity>(),
            };
        }
    }
}
