using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.BookCategoryId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.BookPublishedId);
        }
        //    public DbSet<User> users { get; set; }
        //    public DbSet<Book> books { get; set; }
        //    public DbSet<Category> categories { get; set; }
        //    public DbSet<Publisher> publishers { get; set; }
    }
}
