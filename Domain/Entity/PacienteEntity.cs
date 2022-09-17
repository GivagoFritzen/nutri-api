using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Entity
{
    public class PacienteEntity : BaseEntity
    {
        public Guid NutricionistaEntityId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        [ForeignKey("NutricionistaEntityId")]
        public virtual NutricionistaEntity Nutricionista { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        public List<MedidaEntity> Medidas { get; set; }
        public List<PlanoAlimentarEntity> PlanosAlimentares { get; set; }

        public PacienteEntity()
        {
        }
    }
}