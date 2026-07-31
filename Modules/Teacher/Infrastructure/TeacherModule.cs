using Microsoft.Extensions.DependencyInjection;

namespace Modules.Teacher.Infrastructure
{
    public static class TeacherModule
    {
        public static IServiceCollection AddTeacherModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
