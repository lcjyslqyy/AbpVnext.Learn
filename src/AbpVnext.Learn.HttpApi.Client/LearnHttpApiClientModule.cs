using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace AbpVnext.Learn
{
    [DependsOn(
        typeof(LearnApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class LearnHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Learn";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(LearnApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
