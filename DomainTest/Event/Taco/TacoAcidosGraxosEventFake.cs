using Domain.Event.Taco;

namespace DomainTest.Event.Taco
{
    public static class TacoAcidosGraxosEventFake
    {
        public static TacoAcidosGraxosEvent GetFake()
        {
            return new TacoAcidosGraxosEvent()
            {
                Saturado = TacoQuantidadeEMedidaEventFake.GetFake(),
                Monoinsaturado = TacoQuantidadeEMedidaEventFake.GetFake(),
                Poliinsaturado = TacoQuantidadeEMedidaEventFake.GetFake()
            };
        }
    }
}
