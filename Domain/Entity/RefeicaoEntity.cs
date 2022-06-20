using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class RefeicaoEntity : BaseEntity
    {
        public DateTime Horario { get; set; }
        public string Descricao { get; set; }
        public List<AlimentoEntity> Alimentos { get; set; }
    }
}
