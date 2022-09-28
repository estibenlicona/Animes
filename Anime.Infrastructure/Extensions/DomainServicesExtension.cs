using Anime.Domain.Ports;
using Anime.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Anime.Infrastructure.Extensions
{
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAnimeRulesService), typeof(AnimeRulesService));
            return services;
        }
    }
}
