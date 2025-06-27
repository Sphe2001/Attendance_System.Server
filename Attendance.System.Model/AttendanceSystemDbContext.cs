using Attendance.System.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Attendance.System.Model
{
    public class AttendanceSystemDbContext : DbContext
    {
        public AttendanceSystemDbContext(DbContextOptions<AttendanceSystemDbContext> options) : base(options){ }
        public DbSet<PrivateUser> PrivateUsers { get; set; }
        public DbSet<PlatformUser> PlatformUsers { get; set; }
        public DbSet<UserAttendance> UserAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatformUser>()
             .HasMany(pu => pu.UserAttendances)
             .WithOne(ua => ua.PlatformUser)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
