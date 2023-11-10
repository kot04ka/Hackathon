using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hackathon.EF_Core
{
    public static class DI
    {
        public static void AddEFCore(this IServiceCollection services, IConfiguration configuration)
        {
            var assebmly = Assembly.GetExecutingAssembly();

            //services.AddAutoMapper(assebmly);

            //services.AddDbContext<AuthLinkContext>();
            
            //services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
