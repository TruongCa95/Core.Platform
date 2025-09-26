using Domain.Entities.TimeSheet;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>()
             .HasMany(c => c.TimeSheets)
             .WithMany(t => t.ClassRooms)
             .UsingEntity<ClassRoomTimeSheet>(
                 j => j
                     .HasOne(ct => ct.TimeSheet)
                     .WithMany()
                     .HasForeignKey(ct => ct.TimeSheetId),
                 j => j
                     .HasOne(ct => ct.ClassRoom)
                     .WithMany()
                     .HasForeignKey(ct => ct.ClassRoomId),
                 j => j.ToTable("ClassRoomTimeSheets")
             );

            modelBuilder.Entity<Salary>()
            .Property(p => p.Money)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

            modelBuilder.Entity<TimesheetReview>()
            .Property(p => p.Progress)
            .HasColumnType("decimal(18,2)")
            .IsRequired(false);

            modelBuilder.Entity<Students>()
             .HasMany(s => s.ClassRooms)
             .WithMany(c => c.Students)
             .UsingEntity<StudentClasses>(
                 j => j
                     .HasOne(sc => sc.ClassRoom)
                     .WithMany()
                     .HasForeignKey(sc => sc.ClassId),
                 j => j
                     .HasOne(sc => sc.Students)
                     .WithMany()
                     .HasForeignKey(sc => sc.StudentId),
                 j => j.ToTable("StudentClasses")
             );
        }
    }
}
