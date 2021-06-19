using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Spedy.Desafio.API.AutoMappers;

namespace Spedy.Desafio.API.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mapperConfiguration =>
            {
                mapperConfiguration.AddProfile(new DomainToDtoMapping());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
