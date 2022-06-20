using Domain.Event.Taco;

namespace DomainTest.Event.Taco
{
    public static class TacoEnergiaEventFake
    {
        public static TacoEnergiaEvent GetFake()
        {
            return new TacoEnergiaEvent()
            {
                Quilocaloria = 1,
                Quilojoule = 1
            };
        }
    }
}
