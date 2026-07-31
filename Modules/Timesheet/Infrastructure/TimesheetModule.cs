using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Timesheet.Infrastructure
{
    public static class TimesheetModule
    {
        public static IServiceCollection AddTimesheetModule(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TimesheetModule).Assembly));
            services.AddValidatorsFromAssembly(typeof(TimesheetModule).Assembly);
            return services;
        }
    }
}
