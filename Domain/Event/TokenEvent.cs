using CrossCutting.Authentication;
using Domain.Interface.Event;
using System;

namespace Domain.Event
{
    public class TokenEvent : IEvent
    {
        public string RefreshToken { get; set; }
        public DateTime ExpireAt = AuthenticationSettings.ExpireTime;
    }
}
