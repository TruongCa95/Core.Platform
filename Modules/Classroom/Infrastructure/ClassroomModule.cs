using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Classroom.Infrastructure
{
    public static class ClassroomModule
    {
        public static IServiceCollection AddClassroomModule(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ClassroomModule).Assembly));
            services.AddValidatorsFromAssembly(typeof(ClassroomModule).Assembly);
            return services;
        }
    }
}
