using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Event.Taco
{
    public class TacoEnergiaEvent
    {
        [BsonElement("kcal")]
        public dynamic Quilocaloria { get; set; }
        [BsonElement("kj")]
        public dynamic Quilojoule { get; set; }
    }
}
