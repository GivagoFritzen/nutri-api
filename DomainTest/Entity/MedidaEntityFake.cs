using Domain.Entity;
using System;

namespace DomainTest.Entity
{
    public static class MedidaEntityFake
    {
        public static MedidaEntity GetFake()
        {
            return new MedidaEntity()
            {
                Descricao = "descricao",
                Data = DateTime.Now,
                PesoAtual = 10,
                PesoIdeal = 12,
                Altura = 2,
                Circunferencia = null
            };
        }
    }
}
