using Microsoft.Extensions.DependencyInjection;

namespace Modules.Course.Infrastructure
{
    public static class CourseModule
    {
        public static IServiceCollection AddCourseModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
