using System.Reflection;

namespace Core.Platform
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("PosterManagement")));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("TimeSheetManagement")));
            return services;
        }
    }
}
