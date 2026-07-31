using Microsoft.Extensions.DependencyInjection;

namespace Modules.Notification.Infrastructure
{
    public static class NotificationModule
    {
        public static IServiceCollection AddNotificationModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
