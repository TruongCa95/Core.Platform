using Microsoft.Extensions.DependencyInjection;

namespace Modules.Auth.Infrastructure
{
    public static class AuthModule
    {
        public static IServiceCollection AddAuthModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
