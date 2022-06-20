using Domain.Event.Taco;

namespace DomainTest.Event.Taco
{
    public static class TacoAminoacidosFake
    {
        public static TacoAminoacidos GetFake()
        {
            return new TacoAminoacidos()
            {
                Triptofano = TacoQuantidadeEMedidaEventFake.GetFake(),
                Treonina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Isoleucina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Leucina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Lisina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Metionina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Cistina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Fenilalanina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Tirosina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Valina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Arginina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Histidina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Alanina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Aspartico = TacoQuantidadeEMedidaEventFake.GetFake(),
                Glutamico = TacoQuantidadeEMedidaEventFake.GetFake(),
                Glicina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Prolina = TacoQuantidadeEMedidaEventFake.GetFake(),
                Serina = TacoQuantidadeEMedidaEventFake.GetFake()
            };
        }
    }
}
