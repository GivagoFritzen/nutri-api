using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;

namespace Domain.Repository.Mongo.BsonBaseSerializer
{
    public sealed class TipoMedidaBsonSerializer : IBsonSerializer
    {
        public Type ValueType => typeof(TipoMedida);

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            if (context.Reader.CurrentBsonType == BsonType.String) return GetTipoMedidaValue(context);

            return context.Reader.ReadString();
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            string tipoMedida;

            switch (value)
            {
                case TipoMedida.Percentual:
                    tipoMedida = "percentes";
                    break;
                case TipoMedida.Micrograma:
                    tipoMedida = "mcg";
                    break;
                case TipoMedida.Miligrama:
                    tipoMedida = "mg";
                    break;
                default:
                case TipoMedida.Grama:
                    tipoMedida = "G";
                    break;
            }

            context.Writer.WriteString(tipoMedida);
        }

        private static object GetTipoMedidaValue(BsonDeserializationContext context)
        {
            var value = context.Reader.ReadString();

            switch (value)
            {
                case "percentes":
                    return TipoMedida.Percentual;
                case "mcg":
                    return TipoMedida.Micrograma;
                case "mg":
                    return TipoMedida.Miligrama;
                default:
                case "g":
                    return TipoMedida.Grama;
            }
        }
    }
}
