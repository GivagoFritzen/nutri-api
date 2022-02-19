using Application.ViewModel.Medidas;

namespace ApplicationTest.ViewModel.Circunferencia
{
    public static class CircunferenciaViewModelFake
    {
        public static CircunferenciaViewModel GetFake()
        {
            return new CircunferenciaViewModel()
            {
                BracoRelaxadoDireito = 10,
                BracoRelaxadoEsquerdo = 10,
                BracoContraidoDireito = 10,
                BracoContraidoEsquerdo = 10,
                AntebracoDireito = 10,
                AntebracoEsquerdo = 10,
                PunhoDireito = 10,
                PunhoEsquerdo = 10,
                Pescoco = 10,
                Ombro = 10,
                Peitoral = 10,
                Cintura = 10,
                Abdomen = 10,
                Quadril = 10,
                PanturrilhaDireita = 10,
                PanturrilhaEsquerda = 10,
                CoxaDireita = 10,
                CoxaEsquerda = 10,
                CoxaProximalDireita = 10,
                CoxaProximalEsquerda = 10
            };
        }
    }
}
