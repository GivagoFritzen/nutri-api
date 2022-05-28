namespace Domain.Interface.RabbitMQ
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
