﻿using Application.ViewModel.Medidas;
using Domain.Entity.Medidas;

namespace Application.Mapper
{
    public static class MapperCircunferencia
    {
        public static CircunferenciaEntity ToEntity(this CircunferenciaViewModel model)
        {
            return model == null ? null : new CircunferenciaEntity()
            {
                BracoRelaxadoDireito = model.BracoRelaxadoDireito,
                BracoRelaxadoEsquerdo = model.BracoRelaxadoEsquerdo,
                BracoContraidoDireito = model.BracoContraidoDireito,
                BracoContraidoEsquerdo = model.BracoContraidoEsquerdo,
                AntebracoDireito = model.AntebracoDireito,
                AntebracoEsquerdo = model.AntebracoEsquerdo,
                PunhoDireito = model.PunhoDireito,
                PunhoEsquerdo = model.PunhoEsquerdo,
                Pescoco = model.Pescoco,
                Ombro = model.Ombro,
                Peitoral = model.Peitoral,
                Cintura = model.Cintura,
                Abdomen = model.Abdomen,
                Quadril = model.Quadril,
                PanturrilhaDireita = model.PanturrilhaDireita,
                PanturrilhaEsquerda = model.PanturrilhaEsquerda,
                CoxaDireita = model.CoxaDireita,
                CoxaEsquerda = model.CoxaEsquerda,
                CoxaProximalDireita = model.CoxaProximalDireita,
                CoxaProximalEsquerda = model.CoxaProximalEsquerda
            };
        }

        public static void Update(this CircunferenciaEntity entity, CircunferenciaViewModel model)
        {
            if (entity != null && model != null)
            {
                entity.BracoRelaxadoDireito = model.BracoRelaxadoDireito;
                entity.BracoRelaxadoEsquerdo = model.BracoRelaxadoEsquerdo;
                entity.BracoContraidoDireito = model.BracoContraidoDireito;
                entity.BracoContraidoEsquerdo = model.BracoContraidoEsquerdo;
                entity.AntebracoDireito = model.AntebracoDireito;
                entity.AntebracoEsquerdo = model.AntebracoEsquerdo;
                entity.PunhoDireito = model.PunhoDireito;
                entity.PunhoEsquerdo = model.PunhoEsquerdo;
                entity.Pescoco = model.Pescoco;
                entity.Ombro = model.Ombro;
                entity.Peitoral = model.Peitoral;
                entity.Cintura = model.Cintura;
                entity.Abdomen = model.Abdomen;
                entity.Quadril = model.Quadril;
                entity.PanturrilhaDireita = model.PanturrilhaDireita;
                entity.PanturrilhaEsquerda = model.PanturrilhaEsquerda;
                entity.CoxaDireita = model.CoxaDireita;
                entity.CoxaEsquerda = model.CoxaEsquerda;
                entity.CoxaProximalDireita = model.CoxaProximalDireita;
                entity.CoxaProximalEsquerda = model.CoxaProximalEsquerda;
            };
        }

        public static CircunferenciaViewModel ToViewModel(this CircunferenciaEntity entity)
        {
            return entity == null ? null : new CircunferenciaViewModel()
            {
                BracoRelaxadoDireito = entity.BracoRelaxadoDireito,
                BracoRelaxadoEsquerdo = entity.BracoRelaxadoEsquerdo,
                BracoContraidoDireito = entity.BracoContraidoDireito,
                BracoContraidoEsquerdo = entity.BracoContraidoEsquerdo,
                AntebracoDireito = entity.AntebracoDireito,
                AntebracoEsquerdo = entity.AntebracoEsquerdo,
                PunhoDireito = entity.PunhoDireito,
                PunhoEsquerdo = entity.PunhoEsquerdo,
                Pescoco = entity.Pescoco,
                Ombro = entity.Ombro,
                Peitoral = entity.Peitoral,
                Cintura = entity.Cintura,
                Abdomen = entity.Abdomen,
                Quadril = entity.Quadril,
                PanturrilhaDireita = entity.PanturrilhaDireita,
                PanturrilhaEsquerda = entity.PanturrilhaEsquerda,
                CoxaDireita = entity.CoxaDireita,
                CoxaEsquerda = entity.CoxaEsquerda,
                CoxaProximalDireita = entity.CoxaProximalDireita,
                CoxaProximalEsquerda = entity.CoxaProximalEsquerda
            };
        }
    }
}
