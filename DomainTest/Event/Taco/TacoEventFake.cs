using Domain.Enums;
using Domain.Event.Taco;
using MongoDB.Bson;
using System.Collections.Generic;

namespace DomainTest.Event.Taco
{
    public static class TacoEventFake
    {
        public static TacoEvent GetFake()
        {
            return new TacoEvent()
            {
                Id = ObjectId.GenerateNewId(),
                Descricao = "descricao",
                BaseQuantidade = 1,
                BaseUnidade = TipoMedida.Grama,
                Categoria = TacoCategoria.AlimentosPreparados,
                Atributos = TacoAtributosFake.GetFake(),
                VitaminaC = TacoQuantidadeEMedidaEventFake.GetFake(),
                Re = TacoQuantidadeEMedidaEventFake.GetFake(),
                Rae = TacoQuantidadeEMedidaEventFake.GetFake()
            };
        }

        public static List<TacoEvent> GetListFake()
        {
            return new List<TacoEvent>()
            {
                GetFake()
            };
        }
    }
}