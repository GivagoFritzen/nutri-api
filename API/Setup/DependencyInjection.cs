using Application.Interfaces;
using Application.Services;
using Core.Interfaces.Services;
using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Interfaces.Mongo;
using Infrastructure.Data.Interfaces.RabbitMQ;
using Infrastructure.Data.Messaging;
using Infrastructure.Data.Repositories.Mongo;
using Infrastructure.Data.Repositories.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Services;

namespace API.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISecurityService, SecurityService>();

            // Event Sourcing
            services.AddScoped<IRabbitMQUrlProvider>(x => new AppsettingRabbitMQUrlProvider(configuration));
            services.AddScoped<IMessagingService, MessagingService>();
            services.AddScoped<IEventPublisher, RabbitMQPublisher>();

            //  Nutricionista
            services.AddScoped<IApplicationServiceNutricionista, ApplicationServiceNutricionista>();
            services.AddScoped<INutricionistaService, NutricionistaService>();
            services.AddTransient<IRepositoryBase<NutricionistaEntity>, RepositoryBase<NutricionistaEntity>>();

            //  Paciente
            services.AddScoped<IApplicationServicePaciente, ApplicationServicePaciente>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddTransient<IRepositoryBase<PacienteEntity>, RepositoryBase<PacienteEntity>>();

            // User 
            services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(configuration.GetConnectionString("MongoDb")));
            services.AddSingleton<IUsersMongoRepository, UsersMongoRepository>();
        }
    }
}