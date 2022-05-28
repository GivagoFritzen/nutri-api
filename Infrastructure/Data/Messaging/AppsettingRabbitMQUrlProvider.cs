using Domain.Interface.RabbitMQ;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Messaging
{
    public class AppsettingRabbitMQUrlProvider : IRabbitMQUrlProvider
    {
        private IConfiguration _configuration = null;

        public AppsettingRabbitMQUrlProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Url
        {
            get
            {
                return _configuration["RabbitMQ:Url"];
            }
        }

        public string UserName
        {
            get
            {
                return _configuration["RabbitMQ:UserName"];
            }
        }

        public string Password
        {
            get
            {
                return _configuration["RabbitMQ:Password"];
            }
        }
    }
}
