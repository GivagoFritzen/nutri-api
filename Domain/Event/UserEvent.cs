using System;

namespace Domain.Event
{
    public class UserEvent : GenericEvent
    {
        public UserEvent() { }

        public UserEvent(Guid id, bool delete) : base(id, delete) { }

        public UserEvent(Guid id, string email, string type, bool update = false) :
            base(id, email, type, update)
        { }
    }
}
