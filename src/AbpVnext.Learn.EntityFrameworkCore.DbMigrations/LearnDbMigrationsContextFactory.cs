using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpVnext.Learn.EntityFrameworkCore.DbMigrations
{
    public class LearnDbMigrationsContextFactory : IDesignTimeDbContextFactory<DbM_LearnDbContext>
    {
        public DbM_LearnDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<LearnDbContext>()
                .UseMySql(configuration.GetConnectionString("Learn"));

            return new DbM_LearnDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
