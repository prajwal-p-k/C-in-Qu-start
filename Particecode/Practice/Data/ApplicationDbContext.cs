using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Subject> Subjects1 { get; set; }
        public DbSet<Student> Students2 { get; set; }
    }
}
