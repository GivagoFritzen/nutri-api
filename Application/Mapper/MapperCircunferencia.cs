using Application.ViewModel.Medidas;
using Domain.Entity.Medidas;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mapper
{
    public static class MapperCircunferencia
    {
        public static List<CircunferenciasEntity> ToEntity(this CircunferenciasViewModel circunferenciasViewModel)
        {
            return new List<CircunferenciasEntity>()
            {
                new CircunferenciasEntity()
                {
                     BracoRelaxadoDireito = circunferenciasViewModel.BracoRelaxadoDireito,
                     BracoRelaxadoEsquerdo = circunferenciasViewModel.BracoRelaxadoEsquerdo,
                     BracoContraidoDireito = circunferenciasViewModel.BracoContraidoDireito,
                     BracoContraidoEsquerdo = circunferenciasViewModel.BracoContraidoEsquerdo,
                     AntebracoDireito = circunferenciasViewModel.AntebracoDireito,
                     AntebracoEsquerdo = circunferenciasViewModel.AntebracoEsquerdo,
                     PunhoDireito = circunferenciasViewModel.PunhoDireito,
                     PunhoEsquerdo = circunferenciasViewModel.PunhoEsquerdo,
                     Pescoso = circunferenciasViewModel.Pescoso,
                     Ombro = circunferenciasViewModel.Ombro,
                     Peitoral = circunferenciasViewModel.Peitoral,
                     Cintura = circunferenciasViewModel.Cintura,
                     Abdomen = circunferenciasViewModel.Abdomen,
                     Quadril = circunferenciasViewModel.Quadril,
                     PanturrilhaDireita = circunferenciasViewModel.PanturrilhaDireita,
                     PanturrilhaEsquerda = circunferenciasViewModel.PanturrilhaEsquerda,
                     CoxaDireita = circunferenciasViewModel.CoxaDireita,
                     CoxaEsquerda = circunferenciasViewModel.CoxaEsquerda,
                     CoxaProximalDireita = circunferenciasViewModel.CoxaProximalDireita,
                     CoxaProximalEsquerda = circunferenciasViewModel.CoxaProximalEsquerda
                }
            };
        }

        public static List<CircunferenciasEntity> ToEntity(this List<CircunferenciasViewModel> circunferenciasViewModel)
        {
            return circunferenciasViewModel.Select(circunferencia =>
                 new CircunferenciasEntity()
                 {
                     BracoRelaxadoDireito = circunferencia.BracoRelaxadoDireito,
                     BracoRelaxadoEsquerdo = circunferencia.BracoRelaxadoEsquerdo,
                     BracoContraidoDireito = circunferencia.BracoContraidoDireito,
                     BracoContraidoEsquerdo = circunferencia.BracoContraidoEsquerdo,
                     AntebracoDireito = circunferencia.AntebracoDireito,
                     AntebracoEsquerdo = circunferencia.AntebracoEsquerdo,
                     PunhoDireito = circunferencia.PunhoDireito,
                     PunhoEsquerdo = circunferencia.PunhoEsquerdo,
                     Pescoso = circunferencia.Pescoso,
                     Ombro = circunferencia.Ombro,
                     Peitoral = circunferencia.Peitoral,
                     Cintura = circunferencia.Cintura,
                     Abdomen = circunferencia.Abdomen,
                     Quadril = circunferencia.Quadril,
                     PanturrilhaDireita = circunferencia.PanturrilhaDireita,
                     PanturrilhaEsquerda = circunferencia.PanturrilhaEsquerda,
                     CoxaDireita = circunferencia.CoxaDireita,
                     CoxaEsquerda = circunferencia.CoxaEsquerda,
                     CoxaProximalDireita = circunferencia.CoxaProximalDireita,
                     CoxaProximalEsquerda = circunferencia.CoxaProximalEsquerda
                 }
            ).ToList();
        }

        public static List<CircunferenciasViewModel> ToViewModel(this List<CircunferenciasEntity> circunferencias)
        {
            return circunferencias.Select(circunferencia =>
                new CircunferenciasViewModel()
                {
                    BracoRelaxadoDireito = circunferencia.BracoRelaxadoDireito,
                    BracoRelaxadoEsquerdo = circunferencia.BracoRelaxadoEsquerdo,
                    BracoContraidoDireito = circunferencia.BracoContraidoDireito,
                    BracoContraidoEsquerdo = circunferencia.BracoContraidoEsquerdo,
                    AntebracoDireito = circunferencia.AntebracoDireito,
                    AntebracoEsquerdo = circunferencia.AntebracoEsquerdo,
                    PunhoDireito = circunferencia.PunhoDireito,
                    PunhoEsquerdo = circunferencia.PunhoEsquerdo,
                    Pescoso = circunferencia.Pescoso,
                    Ombro = circunferencia.Ombro,
                    Peitoral = circunferencia.Peitoral,
                    Cintura = circunferencia.Cintura,
                    Abdomen = circunferencia.Abdomen,
                    Quadril = circunferencia.Quadril,
                    PanturrilhaDireita = circunferencia.PanturrilhaDireita,
                    PanturrilhaEsquerda = circunferencia.PanturrilhaEsquerda,
                    CoxaDireita = circunferencia.CoxaDireita,
                    CoxaEsquerda = circunferencia.CoxaEsquerda,
                    CoxaProximalDireita = circunferencia.CoxaProximalDireita,
                    CoxaProximalEsquerda = circunferencia.CoxaProximalEsquerda
                }
            ).ToList();
        }
    }
}
