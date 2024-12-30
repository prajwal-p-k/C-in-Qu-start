using Microsoft.EntityFrameworkCore;
using PayRollMVCCore.Models;

namespace PayRollMVCCore.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        { 

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
