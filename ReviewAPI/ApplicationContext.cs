using Microsoft.EntityFrameworkCore;
using ReviewAPI.Models;

namespace ReviewAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
            var testUser = new User(0, "1234", "1234");
            if (Users.FirstOrDefault(user => user.Login == testUser.Login & user.Password == testUser.Password) != null) 
            {
                return;
            }
            Users.Add(new User(0, "1234", "1234"));
            SaveChanges();
        }
    }
}
