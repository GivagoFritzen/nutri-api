using CrossCutting.Authentication;
using Domain.Interface;
using System;

namespace Domain.Event
{
    public class TokenEvent : IEvent
    {
        public Guid Id { get; set; }
        public bool Delete { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpireAt = AuthenticationSettings.ExpireTime;
    }
}
