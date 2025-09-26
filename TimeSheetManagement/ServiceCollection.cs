using Domain.Entities.TimeSheet;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TimeSheetManagement.Services;
using FluentValidation;
using TimeSheetManagement.Validators;

namespace TimeSheetManagement
{
    public static class ServiceCollection
    {
        public static IServiceCollection RegisterServices (this IServiceCollection services)
        {
            services.AddScoped<ICalculationSalaryService, CalculationSalaryService>();
            services.AddScoped<IRepository<TimeSheet>, Repository<TimeSheet>>();
            services.AddScoped<IRepository<Students>, Repository<Students>>();
            services.AddScoped<IRepository<ClassRoom>, Repository<ClassRoom>>();
            services.AddScoped<IRepository<ClassRoomTimeSheet>, Repository<ClassRoomTimeSheet>>();
            services.AddScoped<IRepository<Salary>, Repository<Salary>>();
            services.AddScoped<IRepository<TimesheetReview>, Repository<TimesheetReview>>();
            services.AddScoped<IRepository<StudentClasses>, Repository<StudentClasses>>();

            services.AddValidatorsFromAssemblyContaining<CreateBaseSalaryCommandValidator>();
            return services;
        }
    }
}
