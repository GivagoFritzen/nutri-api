using Domain.Interface.Event;
using System;

namespace Domain.Event
{
    public class GenericEvent : IEvent
    {
        public bool Update { get; set; }
        public bool Delete { get; set; }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }

        public GenericEvent() { }

        public GenericEvent(Guid id, bool delete)
        {
            Id = id;
            Delete = delete;
        }

        public GenericEvent(Guid id, string type, bool delete)
        {
            Id = id;
            Type = type;
            Delete = delete;
        }

        public GenericEvent(Guid id, string email, string type, bool update = false)
        {
            Id = id;
            Email = email;
            Type = type;
            Update = update;
        }
    }
}
