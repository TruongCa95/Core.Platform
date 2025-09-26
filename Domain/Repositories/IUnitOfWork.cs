using Domain.Entities.TimeSheet;

namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TimeSheet> TimeSheets { get; }
        IRepository<ClassRoom> Classrooms { get; }
        IRepository<ClassRoomTimeSheet> ClassRoomTimeSheets { get; }
        IRepository<Students> Students { get; }
        IRepository<Salary> Salaries { get; }
        IRepository<TimesheetReview> TimesheetReviews { get; }
        IRepository<StudentClasses> StudentClasses { get; }
        Task<int> CompleteAsync();
    }
}
