using Domain.Entity.Medidas;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class MedidaEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public float PesoAtual { get; set; }
        public float PesoIdeal { get; set; }
        public float Altura { get; set; }
        public List<CircunferenciasEntity> Circunferencias { get; set; }
    }
}
