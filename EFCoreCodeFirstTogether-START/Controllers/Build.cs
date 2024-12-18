using EFCoreCodeFirstTogether_START.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreCodeFirstTogether_START
{
    public class Build
    {
        private readonly IConfiguration _configuration;

        public Build(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext BuildApp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            var dbContext = new ApplicationDbContext(options.Options);

            var dataInitializer = new DataInitializer();
            dataInitializer.MigrateAndSeed(dbContext);

            return dbContext;
        }
    }
}
