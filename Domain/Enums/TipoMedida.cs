using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Enums
{
    public enum TipoMedida
    {
        [BsonElement("percents")]
        Percentual,
        [BsonElement("mcg")]
        Micrograma,
        [BsonElement("mg")]
        Miligrama,
        [BsonElement("g")]
        Grama
    }
}
