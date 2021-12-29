using Domain.Event;

namespace Infrastructure.Data.Interfaces.Mongo
{
    public interface IUsersMongoRepository
    {
        void Create(string email);
        UserEvent GetUserByEmail(string email);
        void Remove(string email);
    }
}