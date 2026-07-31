using Domain.Entities.TimeSheet;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace TimeSheetManagement
{
    public static class ServiceCollection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<TimeSheet>, Repository<TimeSheet>>();
            services.AddScoped<IRepository<Students>, Repository<Students>>();
            services.AddScoped<IRepository<ClassRoom>, Repository<ClassRoom>>();
            services.AddScoped<IRepository<ClassRoomTimeSheet>, Repository<ClassRoomTimeSheet>>();
            services.AddScoped<IRepository<Salary>, Repository<Salary>>();
            services.AddScoped<IRepository<TimesheetReview>, Repository<TimesheetReview>>();
            services.AddScoped<IRepository<StudentClasses>, Repository<StudentClasses>>();
            services.AddScoped<IRepository<TeacherClassMonthlyKPI>, Repository<TeacherClassMonthlyKPI>>();
            services.AddScoped<IRepository<KPICriteria>, Repository<KPICriteria>>();
            services.AddScoped<IRepository<KPIScale>, Repository<KPIScale>>();

            return services;
        }
    }
}
