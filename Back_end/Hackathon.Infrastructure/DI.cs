using Hackathon.Application.Services;
using Hackathon.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Infrastructure
{
    public static class DI
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRouteService, RouteService>();
        }
    }
}
