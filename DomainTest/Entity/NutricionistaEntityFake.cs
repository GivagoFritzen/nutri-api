using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTest.Entity
{
    public class NutricionistaEntityFake
    {
        public static NutricionistaEntity GetFake()
        {
            return new NutricionistaEntity()
            {
                Senha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "email",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                PacientesIds = new List<Guid>()
            };
        }
    }
}
