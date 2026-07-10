using System.Reflection;
using TimeSheetManagement.Behaviors;

namespace Core.Platform
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.Load("TimeSheetManagement"));
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            return services;
        }
    }
}
