using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Naruto.Infrastructure.Configs;

namespace Naruto.Infrastructure.Extensions
{
    public static class ConfigExtension
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            ApiJinkaConfig apiJinkaConfig = new ApiJinkaConfig();
            apiJinkaConfig.EndPoint = configuration.GetValue<string>("ApiJinka:EndPoint");
            apiJinkaConfig.AnimeResource = configuration.GetValue<string>("ApiJinka:Anime");
            services.AddSingleton(api => apiJinkaConfig);
            return services;
        }
    }
}
