using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Event.Taco
{
    [BsonIgnoreExtraElements]
    public class TacoAtributos
    {
        [BsonElement("humidity")]
        public TacoQuantidadeEMedidaEvent Humidade { get; set; }
        [BsonElement("protein")]
        public TacoQuantidadeEMedidaEvent Proteina { get; set; }
        [BsonElement("lipid")]
        public TacoQuantidadeEMedidaEvent Lipidio { get; set; }
        [BsonElement("cholesterol")]
        public TacoQuantidadeEMedidaEvent Colesterol { get; set; }
        [BsonElement("carbohydrate")]
        public TacoQuantidadeEMedidaEvent Carboidrato { get; set; }
        [BsonElement("fiber")]
        public TacoQuantidadeEMedidaEvent Fibra { get; set; }
        [BsonElement("ashes")]
        public TacoQuantidadeEMedidaEvent Cinzas { get; set; }
        [BsonElement("calcium")]
        public TacoQuantidadeEMedidaEvent Calcio { get; set; }
        [BsonElement("magnesium")]
        public TacoQuantidadeEMedidaEvent Magnesio { get; set; }
        [BsonElement("phosphorus")]
        public TacoQuantidadeEMedidaEvent Fosforo { get; set; }
        [BsonElement("iron")]
        public TacoQuantidadeEMedidaEvent Ferro { get; set; }
        [BsonElement("sodium")]
        public TacoQuantidadeEMedidaEvent Sodio { get; set; }
        [BsonElement("potassium")]
        public TacoQuantidadeEMedidaEvent Potassio { get; set; }
        [BsonElement("copper")]
        public TacoQuantidadeEMedidaEvent Cobre { get; set; }
        [BsonElement("zinc")]
        public TacoQuantidadeEMedidaEvent Zinco { get; set; }
        [BsonElement("retinol")]
        public TacoQuantidadeEMedidaEvent Retinol { get; set; }
        [BsonElement("thiamine")]
        public TacoQuantidadeEMedidaEvent Tiamina { get; set; }
        [BsonElement("riboflavin")]
        public TacoQuantidadeEMedidaEvent Riboflavina { get; set; }
        [BsonElement("pyridoxine")]
        public TacoQuantidadeEMedidaEvent Piridoxina { get; set; }
        [BsonElement("niacin")]
        public TacoQuantidadeEMedidaEvent Niacina { get; set; }
        [BsonElement("energy")]
        public TacoEnergiaEvent Energia { get; set; }
        [BsonElement("fatty_acids")]
        public TacoAcidosGraxosEvent AcidosGraxos { get; set; }
        [BsonElement("manganese")]
        public TacoQuantidadeEMedidaEvent Manganes { get; set; }
        [BsonElement("amino_acids")]
        public TacoAminoacidos Aminoacidos { get; set; }
    }
}
