using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Event.Taco
{
    public class TacoAminoacidos
    {
        [BsonElement("tryptophan")]
        public TacoQuantidadeEMedidaEvent Triptofano { get; set; }
        [BsonElement("threonine")]
        public TacoQuantidadeEMedidaEvent Treonina { get; set; }
        [BsonElement("isoleucine")]
        public TacoQuantidadeEMedidaEvent Isoleucina { get; set; }
        [BsonElement("leucine")]
        public TacoQuantidadeEMedidaEvent Leucina { get; set; }
        [BsonElement("lysine")]
        public TacoQuantidadeEMedidaEvent Lisina { get; set; }
        [BsonElement("methionine")]
        public TacoQuantidadeEMedidaEvent Metionina { get; set; }
        [BsonElement("cystine")]
        public TacoQuantidadeEMedidaEvent Cistina { get; set; }
        [BsonElement("phenylalanine")]
        public TacoQuantidadeEMedidaEvent Fenilalanina { get; set; }
        [BsonElement("tyrosine")]
        public TacoQuantidadeEMedidaEvent Tirosina { get; set; }
        [BsonElement("valine")]
        public TacoQuantidadeEMedidaEvent Valina { get; set; }
        [BsonElement("arginine")]
        public TacoQuantidadeEMedidaEvent Arginina { get; set; }
        [BsonElement("histidine")]
        public TacoQuantidadeEMedidaEvent Histidina { get; set; }
        [BsonElement("alanine")]
        public TacoQuantidadeEMedidaEvent Alanina { get; set; }
        [BsonElement("aspartic")]
        public TacoQuantidadeEMedidaEvent Aspartico { get; set; }
        [BsonElement("glutamic")]
        public TacoQuantidadeEMedidaEvent Glutamico { get; set; }
        [BsonElement("glycine")]
        public TacoQuantidadeEMedidaEvent Glicina { get; set; }
        [BsonElement("proline")]
        public TacoQuantidadeEMedidaEvent Prolina { get; set; }
        [BsonElement("serine")]
        public TacoQuantidadeEMedidaEvent Serina { get; set; }
    }
}
