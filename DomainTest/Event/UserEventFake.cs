using Domain.Event;

namespace DomainTest.Event
{
    public static class UserEventFake
    {
        public static UserEvent GetUserEventEmailFake()
        {
            return new UserEvent()
            {
                Email = "teste@teste.com"
            };
        }
    }
}
