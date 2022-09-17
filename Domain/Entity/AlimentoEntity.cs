using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Entity
{
    public class AlimentoEntity : BaseEntity
    {
        public Guid RefeicaoEntityId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        [ForeignKey("RefeicaoEntityId")]
        public virtual RefeicaoEntity Refeicao { get; set; }

        public string Nome { get; set; }
        public MedidaCaseira Medida { get; set; }
        public int Quantidade { get; set; }
    }
}
