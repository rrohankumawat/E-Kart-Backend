using EKart.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EKart.Infrastructure.AppDbContext
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
