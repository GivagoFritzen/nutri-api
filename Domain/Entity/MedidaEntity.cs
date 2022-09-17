using Domain.Entity.Medidas;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Entity
{
    public class MedidaEntity : BaseEntity
    {
        public Guid PacienteEntityId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        [ForeignKey("PacienteEntityId")]
        public virtual PacienteEntity Paciente { get; set; }

        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public float PesoAtual { get; set; }
        public float PesoIdeal { get; set; }
        public float Altura { get; set; }

        public Guid CircunferenciaId { get; set; }
        [ForeignKey("CircunferenciaId")]
        public CircunferenciaEntity Circunferencia { get; set; }
    }
}
