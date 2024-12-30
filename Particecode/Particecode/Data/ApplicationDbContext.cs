//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Particecode.Models;

namespace Particecode.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Student> students { get; set; }

    }
}
