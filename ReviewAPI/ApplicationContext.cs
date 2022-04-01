using Microsoft.EntityFrameworkCore;
using ReviewAPI.Models;

namespace ReviewAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
