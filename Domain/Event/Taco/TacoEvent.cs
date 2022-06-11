using Domain.Enums;
using Domain.Interface.Event;
using Domain.Repository.Mongo.BsonBaseSerializer;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Event.Taco
{
    [BsonIgnoreExtraElements]
    public class TacoEvent : IEvent
    {
        [BsonElement("id")]
        public ObjectId Id { get; set; }
        [BsonElement("description")]
        public string Descricao { get; set; }
        [BsonElement("base_qty")]
        public int BaseQuantidade { get; set; }
        [BsonElement("base_unit")]
        [BsonSerializer(typeof(TipoMedidaBsonSerializer))]
        public TipoMedida BaseUnidade { get; set; }
        [BsonElement("category_id")]
        public TacoCategoria Categoria { get; set; }
        [BsonElement("attributes")]
        public TacoAtributos Atributos { get; set; }
        [BsonElement("vitaminC")]
        public TacoQuantidadeEMedidaEvent VitaminaC { get; set; }
        [BsonElement("re")]
        public TacoQuantidadeEMedidaEvent Re { get; set; }
        [BsonElement("rea")]
        public TacoQuantidadeEMedidaEvent Rae { get; set; }
    }
}
