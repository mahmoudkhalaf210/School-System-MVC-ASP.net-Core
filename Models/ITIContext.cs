using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Day2.Models
{
    public class ITIContext: IdentityDbContext<ApplicationUser>
    {
        public ITIContext(): base()
        {

        }

        public ITIContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GQJS1PP;Database=University;Trusted_Connection=True;");
        }
    }
}
