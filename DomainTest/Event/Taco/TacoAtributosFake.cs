using Domain.Event.Taco;

namespace DomainTest.Event.Taco
{
    public static class TacoAtributosFake
    {
        public static TacoAtributos GetFake()
        {
            return new TacoAtributos()
            {
                Humidade = TacoQuantidadeEMedidaEventFake.GetFake(),
                Proteina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Lipidio = TacoQuantidadeEMedidaEventFake.GetFake(),
                Colesterol = TacoQuantidadeEMedidaEventFake.GetFake(),
                Carboidrato = TacoQuantidadeEMedidaEventFake.GetFake(),
                Fibra = TacoQuantidadeEMedidaEventFake.GetFake(),
                Cinzas = TacoQuantidadeEMedidaEventFake.GetFake(),
                Calcio = TacoQuantidadeEMedidaEventFake.GetFake(),
                Magnesio = TacoQuantidadeEMedidaEventFake.GetFake(),
                Fosforo = TacoQuantidadeEMedidaEventFake.GetFake(),
                Ferro = TacoQuantidadeEMedidaEventFake.GetFake(),
                Sodio = TacoQuantidadeEMedidaEventFake.GetFake(),
                Potassio = TacoQuantidadeEMedidaEventFake.GetFake(),
                Cobre = TacoQuantidadeEMedidaEventFake.GetFake(),
                Zinco = TacoQuantidadeEMedidaEventFake.GetFake(),
                Retinol = TacoQuantidadeEMedidaEventFake.GetFake(),
                Tiamina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Riboflavina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Piridoxina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Niacina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Energia = TacoEnergiaEventFake.GetFake(),
                AcidosGraxos = TacoAcidosGraxosEventFake.GetFake(),
                Manganes = TacoQuantidadeEMedidaEventFake.GetFake(),
                Aminoacidos = TacoAminoacidosFake.GetFake()
            };
        }
    }
}
