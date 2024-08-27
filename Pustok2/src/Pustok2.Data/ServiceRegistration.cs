using Microsoft.Extensions.DependencyInjection;
using Pustok2.Core.Repositories;
using Pustok2.Data.Repositories;

namespace Pustok2.Data
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ISlideRepository, SlideRepository>();
		}
    }
}
