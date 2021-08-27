using Application.Interfaces;
using Application.Interfaces.Mapper;
using Application.Mapper;
using Application.Services;
using Core.Interfaces.Services;
using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace API.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(provider => new DataContext());
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Paciente
            services.AddScoped<IApplicationServicePaciente, ApplicationServicePaciente>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IMapperPaciente, MapperPaciente>();

            services.AddTransient<IRepositoryBase<Paciente>, RepositoryBase<Paciente>>();
        }
    }
}