using Application.Interfaces;
using Application.Services;
using Application.Validation.Nutricionistas;
using Core.Interfaces.Services;
using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            //  Nutricionista
            services.AddScoped<IApplicationServiceNutricionista, ApplicationServiceNutricionista>();
            services.AddScoped<INutricionistaService, NutricionistaService>();
            services.AddTransient<IRepositoryBase<NutricionistaEntity>, RepositoryBase<NutricionistaEntity>>();

            //  Paciente
            services.AddScoped<IApplicationServicePaciente, ApplicationServicePaciente>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddTransient<IRepositoryBase<PacienteEntity>, RepositoryBase<PacienteEntity>>();
        }
    }
}