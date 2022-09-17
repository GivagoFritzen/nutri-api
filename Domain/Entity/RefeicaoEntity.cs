using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Entity
{
    public class RefeicaoEntity : BaseEntity
    {
        public Guid PlanoAlimentarEntityId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        [ForeignKey("PlanoAlimentarEntityId")]
        public virtual PlanoAlimentarEntity PlanoAlimentar { get; set; }

        public DateTime Horario { get; set; }
        public string Descricao { get; set; }
        public List<AlimentoEntity> Alimentos { get; set; }
    }
}
