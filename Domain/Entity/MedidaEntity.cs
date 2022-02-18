using Domain.Entity.Medidas;
using System;

namespace Domain.Entity
{
    public class MedidaEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public float PesoAtual { get; set; }
        public float PesoIdeal { get; set; }
        public float Altura { get; set; }
        public CircunferenciaEntity Circunferencia { get; set; }
    }
}
