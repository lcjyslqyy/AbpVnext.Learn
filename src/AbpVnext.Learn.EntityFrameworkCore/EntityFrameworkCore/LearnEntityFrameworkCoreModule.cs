using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Microsoft.EntityFrameworkCore;

namespace AbpVnext.Learn.EntityFrameworkCore
{
    [DependsOn(
        typeof(LearnDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class LearnEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<LearnDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });


            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(ctx =>
                {
                    if (ctx.ExistingConnection != null)
                    {
                        ctx.DbContextOptions.UseMySql(ctx.ExistingConnection);
                    }
                    else
                    {
                        ctx.DbContextOptions.UseMySql(ctx.ConnectionString);
                    }
                });
            });
        }
    }
}