using Microsoft.EntityFrameworkCore;

namespace DotNetAPİDemo.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Post> Posts { get; set; }
    }
}