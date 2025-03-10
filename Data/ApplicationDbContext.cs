using Microsoft.EntityFrameworkCore;
using RepoUoWdemo.Models;

namespace RepoUoWdemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
