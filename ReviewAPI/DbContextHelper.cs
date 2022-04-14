using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ReviewAPI
{
    /// <summary>
    /// Класс для получения опций для ApplicationContext
    /// </summary>
    public static class DbContextHelper
    {
        public static DbContextOptions<ApplicationContext> GetDbContextOptions()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return new DbContextOptionsBuilder<ApplicationContext>()
                  .UseSqlServer(new SqlConnection(configuration.GetConnectionString("ReviewDatabase"))).Options;

        }
    }
}
