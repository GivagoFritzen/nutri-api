using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Event.Taco
{
    [BsonIgnoreExtraElements]
    public class TacoAcidosGraxosEvent
    {
        [BsonElement("saturated")]
        public TacoQuantidadeEMedidaEvent Saturado { get; set; }
        [BsonElement("monounsaturated")]
        public TacoQuantidadeEMedidaEvent Monoinsaturado { get; set; }
        [BsonElement("polyunsaturated")]
        public TacoQuantidadeEMedidaEvent Poliinsaturado { get; set; }
    }
}
