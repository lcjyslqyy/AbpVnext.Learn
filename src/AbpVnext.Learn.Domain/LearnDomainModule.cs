using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpVnext.Learn
{
    [DependsOn(
        typeof(LearnDomainSharedModule)
        )]
    public class LearnDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });
        }
    }
}
