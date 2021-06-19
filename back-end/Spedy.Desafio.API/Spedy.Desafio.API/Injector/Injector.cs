using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spedy.Desafio.API.Infrastructure.Data;
using Spedy.Desafio.API.Infrastructure.Data.Repositories;
using Spedy.Desafio.API.Infrastructure.Data.UnitOfWork;
using Spedy.Desafio.API.Interfaces.Repositories;
using Spedy.Desafio.API.Interfaces.Services;
using Spedy.Desafio.API.Interfaces.UnityOfWork;
using Spedy.Desafio.API.Services;

namespace Spedy.Desafio.API.Injector
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Entity Framework
            services.AddScoped<DataContext>();

            services.AddDbContext<DataContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Unity Of Work
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            // Services
            services.AddScoped<IClassifiedService, ClassifiedService>();

            // Repositories
            services.AddScoped<IClassifiedRepository, ClassifiedRepository>();

            // Validators

            // Configuration
        }
    }
}
