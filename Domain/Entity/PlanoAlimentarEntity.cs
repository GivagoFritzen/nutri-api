using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class PlanoAlimentarEntity : BaseEntity
    {
        public DateTime Data { get; set; }
        public List<RefeicaoEntity> Refeicoes { get; set; } = new List<RefeicaoEntity>();
    }
}
