using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class NutricionistaEntity : BaseEntity
    {
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        [NotMapped]
        public List<Guid> PacientesIds { get; set; }
    }
}
