using CrossCuttingTest;
using Domain.Entity;
using System.Collections.Generic;

namespace DomainTest.Entity
{
    public static class PlanoAlimentarEntityFake
    {
        public static PlanoAlimentarEntity GetFake()
        {
            return new PlanoAlimentarEntity()
            {
                Data = DataFake.GetDateTime(),
                Refeicoes = RefeicaoEntityFake.GetListFake()
            };
        }

        public static List<PlanoAlimentarEntity> GetListFake()
        {
            return new List<PlanoAlimentarEntity>()
            {
                GetFake()
            };
        }
    }
}
