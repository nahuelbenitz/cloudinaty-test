using CloudinaryTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudinaryTest.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
