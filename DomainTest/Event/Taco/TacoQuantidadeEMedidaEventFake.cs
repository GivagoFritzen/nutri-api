using Domain.Enums;
using Domain.Event.Taco;

namespace DomainTest.Event.Taco
{
    public static class TacoQuantidadeEMedidaEventFake
    {
        public static TacoQuantidadeEMedidaEvent GetFake()
        {
            return new TacoQuantidadeEMedidaEvent()
            {
                Quantidade = 1,
                Medida = TipoMedida.Grama
            };
        }
    }
}
