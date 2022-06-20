using Domain.Enums;

namespace Domain.Entity
{
    public class AlimentoEntity : BaseEntity
    {
        public string Nome { get; set; }
        public MedidaCaseira Medida { get; set; }
        public int Quantidade { get; set; }
    }
}
