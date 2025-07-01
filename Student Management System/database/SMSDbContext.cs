using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models.Entity;

namespace Student_Management_System.database
{
    public class SMSDbContext : DbContext
    {
        public SMSDbContext(DbContextOptions options) : base(options) { }
   

    public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
