using Application.Interfaces;
using Application.Services;
using Domain.Entity;
using Domain.Interface.RabbitMQ;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Base;
using Domain.Interface.Repository.Mongo;
using Domain.Interface.Repository.RabbitMQ;
using Domain.Interface.Services;
using Domain.Repository;
using Domain.Services;
using Infrastructure.Data.Messaging;
using Infrastructure.Data.Messaging.BackgroundsQueue;
using Infrastructure.Data.Repositories.Mongo;
using Infrastructure.Data.Repositories.SQL;
using Infrastructure.Data.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace API.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISecurityService, SecurityService>();

            services.AddDbContext<SQLDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Mongo
            services.AddSingleton<IMongoDbContext, MongoDbContext>();

            // Event Sourcing
            services.AddScoped<IRabbitMQUrlProvider>(x => new AppsettingRabbitMQUrlProvider(configuration));

            services.AddSingleton<IBackgroundQueue, UserEventQueue>();
            services.AddSingleton<IBackgroundQueue, PacienteEventQueue>();
            services.AddSingleton<IBackgroundQueue, NutricionistaEventQueue>();

            services.AddHostedService<RabbitMQSubscriber>();
            services.AddScoped<IMessagingService, MessagingService>();
            services.AddScoped<IEventPublisher, RabbitMQPublisher>();

            //  Nutricionista
            services.AddScoped<IApplicationServiceNutricionista, ApplicationServiceNutricionista>();
            services.AddScoped<INutricionistaRepository, NutricionistaRepository>();
            services.AddTransient<IRepositorySQL<NutricionistaEntity>, RepositorySQLBase<NutricionistaEntity>>();

            //  Paciente
            services.AddScoped<IApplicationServicePaciente, ApplicationServicePaciente>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IRepositorySQL<PacienteEntity>, RepositorySQLBase<PacienteEntity>>();

            // User 
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(configuration.GetConnectionString("MongoConnection")));

            //  Login
            services.AddScoped<IApplicationServiceLogin, ApplicationServiceLogin>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITokenRepository, TokenRepository>();
        }
    }
}