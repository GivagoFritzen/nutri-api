namespace Infrastructure.Data.Interfaces.RabbitMQ
{
    public interface IRabbitMQUrlProvider
    {
        string Url
        {
            get;
        }

        string UserName { get; }

        string Password { get; }
    }
}
