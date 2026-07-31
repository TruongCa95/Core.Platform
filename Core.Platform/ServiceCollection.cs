using TimeSheetManagement.Behaviors;

namespace Core.Platform
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(Modules.Student.Infrastructure.StudentModule).Assembly,
                    typeof(Modules.Classroom.Infrastructure.ClassroomModule).Assembly,
                    typeof(Modules.Timesheet.Infrastructure.TimesheetModule).Assembly,
                    typeof(Modules.Payroll.Infrastructure.PayrollModule).Assembly
                );
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            return services;
        }
    }
}
