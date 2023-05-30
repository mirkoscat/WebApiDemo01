using Microsoft.EntityFrameworkCore;
using WebApiDemo01.Models;

namespace WebApiDemo01.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
            
        }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductPrice)
                .HasPrecision(18, 2);
        }

    }
}
