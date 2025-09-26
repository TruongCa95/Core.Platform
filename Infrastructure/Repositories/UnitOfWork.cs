using Domain.Entities.TimeSheet;
using Domain.Repositories;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlDBContext _context;
        private IRepository<TimeSheet> _timeSheetRepository;
        private IRepository<ClassRoom> _classroomRepository;
        private IRepository<ClassRoomTimeSheet> _classroomTimesheetRepository;
        private IRepository<Students> _studentRepository;
        private IRepository<Salary> _salaryRepository;
        private IRepository<TimesheetReview> _timesheetReviewRepository;
        private IRepository<StudentClasses> _studentClassesRepository;

        public UnitOfWork(MySqlDBContext context, 
            IRepository<TimeSheet> timeSheetRepository,
            IRepository<ClassRoom> classroomRepository,
            IRepository<ClassRoomTimeSheet> classroomTimesheetRepository,
            IRepository<Students> studentRepository,
            IRepository<Salary> salaryRepository,
            IRepository<TimesheetReview> timesheetReviewRepository,
            IRepository<StudentClasses> studentClassesRepository)
        {
            _context = context;
            _timeSheetRepository = timeSheetRepository;
            _classroomRepository = classroomRepository;
            _studentRepository = studentRepository;
            _salaryRepository = salaryRepository;
            _classroomTimesheetRepository = classroomTimesheetRepository;
            _timesheetReviewRepository = timesheetReviewRepository;
            _studentClassesRepository = studentClassesRepository;
        }

        public IRepository<TimeSheet> TimeSheets
        {
            get
            {
                return _timeSheetRepository ??= new Repository<TimeSheet>(_context);
            }
        }

        public IRepository<ClassRoom> Classrooms
        {
            get
            {
                return _classroomRepository ??= new Repository<ClassRoom>(_context);
            }
        }

        public IRepository<ClassRoomTimeSheet> ClassRoomTimeSheets
        {
            get
            {
                return _classroomTimesheetRepository ??= new Repository<ClassRoomTimeSheet>(_context);
            }
        }

        public IRepository<Students> Students
        {
            get
            {
                return _studentRepository ??= new Repository<Students>(_context);
            }
        }

        public IRepository<Salary> Salaries
        {
            get
            {
                return _salaryRepository ??= new Repository<Salary>(_context);
            }
        }

        public IRepository<TimesheetReview> TimesheetReviews
        {
            get
            {
                return _timesheetReviewRepository ??= new Repository<TimesheetReview>(_context);
            }
        }

        public IRepository<StudentClasses> StudentClasses
        {
            get
            {
                return _studentClassesRepository ??= new Repository<StudentClasses>(_context);
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
