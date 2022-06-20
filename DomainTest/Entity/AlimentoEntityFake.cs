using Domain.Entity;
using Domain.Enums;
using System.Collections.Generic;

namespace DomainTest.Entity
{
    public static class AlimentoEntityFake
    {
        public static AlimentoEntity GetFake()
        {
            return new AlimentoEntity()
            {
                Nome = "nome",
                Medida = MedidaCaseira.Grama,
                Quantidade = 1
            };
        }

        public static IEnumerable<AlimentoEntity> GetListFake()
        {
            return new List<AlimentoEntity>
            {
                GetFake()
            };
        }
    }
}
