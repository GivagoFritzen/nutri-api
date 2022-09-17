using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Entity
{
    public class PlanoAlimentarEntity : BaseEntity
    {
        public Guid PacienteEntityId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        [ForeignKey("PacienteEntityId")]
        public virtual PacienteEntity Paciente { get; set; }

        public DateTime Data { get; set; }
        public List<RefeicaoEntity> Refeicoes { get; set; } = new List<RefeicaoEntity>();
    }
}
