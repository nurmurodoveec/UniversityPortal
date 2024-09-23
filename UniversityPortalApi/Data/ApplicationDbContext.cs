using Microsoft.EntityFrameworkCore;
using UniversityPortal.Api.Models;

namespace UniversityPortal.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
    }
}
