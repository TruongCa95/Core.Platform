using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Student.Infrastructure
{
    public static class StudentModule
    {
        public static IServiceCollection AddStudentModule(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(StudentModule).Assembly));
            services.AddValidatorsFromAssembly(typeof(StudentModule).Assembly);
            return services;
        }
    }
}
