﻿namespace Domain.Entity.Medidas
{
    public class CircunferenciasEntity : BaseEntity
    {
        //  Membros Superiores
        public float BracoRelaxadoDireito { get; set; }
        public float BracoRelaxadoEsquerdo { get; set; }
        public float BracoContraidoDireito { get; set; }
        public float BracoContraidoEsquerdo { get; set; }

        public float AntebracoDireito { get; set; }
        public float AntebracoEsquerdo { get; set; }

        public float PunhoDireito { get; set; }
        public float PunhoEsquerdo { get; set; }

        //  Tronco
        public float Pescoso { get; set; }
        public float Ombro { get; set; }
        public float Peitoral { get; set; }
        public float Cintura { get; set; }
        public float Abdomen { get; set; }
        public float Quadril { get; set; }

        //  Membros Inferiores
        public float PanturrilhaDireita { get; set; }
        public float PanturrilhaEsquerda { get; set; }
        public float CoxaDireita { get; set; }
        public float CoxaEsquerda { get; set; }
        public float CoxaProximalDireita { get; set; }
        public float CoxaProximalEsquerda { get; set; }
    }
}
