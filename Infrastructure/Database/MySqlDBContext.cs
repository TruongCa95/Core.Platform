using Domain.Entities.TimeSheet;
using Infrastructure.Database.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class MySqlDBContext : DbContext
    {
        public MySqlDBContext(DbContextOptions<MySqlDBContext> options) : base(options)
        {
        }

        public DbSet<TimeSheet> TimeSheets { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Salary> SalaryRooms { get; set; }

        public DbSet<Students> Students { get; set; }

        public DbSet<ClassRoomTimeSheet> ClassRoomTimeSheets { get; set; }

        public DbSet<TimesheetReview> TimesheetReviews { get; set; }

        public DbSet<TeacherClassMonthlyKPI> TeacherClassMonthlyKPIs { get; set; }

        public DbSet<KPICriteria> KPICriterias { get; set; }

        public DbSet<KPIScale> KPIScales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherClassMonthlyKPI>(entity =>
            {
                entity.HasIndex(e => new { e.ClassroomId, e.Year, e.Month }).IsUnique();
                entity.HasOne(e => e.ClassRoom)
                      .WithMany()
                      .HasForeignKey(e => e.ClassroomId);
            });

            modelBuilder.Entity<ClassRoomTimeSheet>(ct =>
            {
                ct.ToTable("ClassRoomTimeSheets");
                ct.HasOne(x => x.TimeSheet).WithMany().HasForeignKey(x => x.TimeSheetId);
                ct.HasOne(x => x.ClassRoom).WithMany().HasForeignKey(x => x.ClassRoomId);
            });

            modelBuilder.Entity<Salary>()
            .Property(p => p.Money)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

            modelBuilder.Entity<TimesheetReview>()
            .Property(p => p.Progress)
            .HasColumnType("decimal(18,2)")
            .IsRequired(false);

            modelBuilder.Entity<StudentClasses>(sc =>
            {
                sc.ToTable("StudentClasses");
                sc.HasOne(x => x.ClassRoom).WithMany().HasForeignKey(x => x.ClassId);
                sc.HasOne(x => x.Students).WithMany().HasForeignKey(x => x.StudentId);
            });

            modelBuilder.SeedKPICriteriaAndScales();
        }
    }
}
