using Domain.Interface.Event;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Domain.Event
{
    public class TokenEvent : IEvent
    {
        public string RefreshToken { get; set; }
        [BsonElement()]
        public DateTime ExpireAt;
    }
}
