using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TimeSheetManagement.Services;

namespace Modules.Payroll.Infrastructure
{
    public static class PayrollModule
    {
        public static IServiceCollection AddPayrollModule(this IServiceCollection services)
        {
            services.AddScoped<ICalculationSalaryService, CalculationSalaryService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PayrollModule).Assembly));
            services.AddValidatorsFromAssembly(typeof(PayrollModule).Assembly);
            return services;
        }
    }
}
