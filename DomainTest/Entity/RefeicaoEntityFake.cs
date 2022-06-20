using CrossCuttingTest;
using Domain.Entity;
using System.Collections.Generic;

namespace DomainTest.Entity
{
    public static class RefeicaoEntityFake
    {
        public static List<RefeicaoEntity> GetListFake()
        {
            return new List<RefeicaoEntity>()
            {
                new RefeicaoEntity()
                {
                    Horario = DataFake.GetDateTime(),
                    Descricao = "descricao",
                    Alimentos = new List<AlimentoEntity>()
                    {
                        AlimentoEntityFake.GetFake()
                    }
                }
            };
        }
    }
}
