using Microsoft.Extensions.DependencyInjection;
using Naruto.Domain.Ports;
using Naruto.Infrastructure.Adapters;

namespace Naruto.Infrastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAnimeAdapter), typeof(AnimeAdapter));
            return services;
        }
    }
}
