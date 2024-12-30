using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeAPI.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
