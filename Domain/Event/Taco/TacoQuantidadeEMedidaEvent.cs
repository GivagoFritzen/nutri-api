using Domain.Enums;
using Domain.Repository.Mongo.BsonBaseSerializer;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Event.Taco
{

    public class TacoQuantidadeEMedidaEvent
    {
        [BsonElement("qty")]
        public dynamic Quantidade { get; set; }
        [BsonElement("unit")]
        [BsonSerializer(typeof(TipoMedidaBsonSerializer))]
        public TipoMedida Medida { get; set; }
    }
}
