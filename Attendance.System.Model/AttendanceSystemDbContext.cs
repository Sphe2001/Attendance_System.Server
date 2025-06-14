using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance.System.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Attendance.System.Model
{
    public class AttendanceSystemDbContext : DbContext
    {
        public AttendanceSystemDbContext(DbContextOptions<AttendanceSystemDbContext> options) : base(options){ }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<FaceData> FaceDatas { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<ClassAttendance> ClassAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
             .HasOne(a => a.UserAccount)
             .WithOne(u => u.Admin)
             .HasForeignKey<Admin>(a => a.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Staff>()
             .HasOne(s => s.UserAccount)
             .WithOne(u => u.Staff)
             .HasForeignKey<Staff>(s => s.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
             .HasOne(s => s.UserAccount)
             .WithOne(u => u.Student)
             .HasForeignKey<Student>(s => s.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Admin>()
               .HasOne(a => a.Faculty)
               .WithMany(f => f.Admins)
               .HasForeignKey(a => a.FacultyId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Staff>()
               .HasOne(s => s.Department)
               .WithMany(d => d.Staffs)
               .HasForeignKey(s => s.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
               .HasOne(d => d.Faculty)
               .WithMany(f => f.Departments)
               .HasForeignKey(d => d.FacultyId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
               .HasOne(c => c.Department)
               .WithMany(d => d.Courses)
               .HasForeignKey(c => c.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Module>()
               .HasOne(m => m.Course)
               .WithMany(c => c.Modules)
               .HasForeignKey(m => m.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Group>()
               .HasOne(g => g.Module)
               .WithMany(m => m.Groups)
               .HasForeignKey(g => g.ModuleId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>()
               .HasOne(c => c.Group)
               .WithMany(g => g.Classes)
               .HasForeignKey(c => c.GroupId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentAttendance>()
               .HasOne(sa => sa.Class)
               .WithMany(c => c.StudentAttendances)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassAttendance>()
               .HasOne(ca => ca.Class)
               .WithMany(c => c.ClassAttendances)
               .HasForeignKey(ca => ca.ClassId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentAttendance>()
               .HasOne(sa => sa.Student)
               .WithMany(s => s.Attendances)
               .HasForeignKey(sa => sa.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
              .HasOne(s => s.Group)
              .WithMany(g => g.Students)
              .HasForeignKey(s => s.GroupId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FaceData>()
             .HasOne(fd => fd.Student)
             .WithOne(s => s.FaceData)
             .HasForeignKey<Student>(fd => fd.StudentId)
             .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
