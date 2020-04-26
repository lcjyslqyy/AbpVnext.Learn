using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AbpVnext.Learn
{
    [DependsOn(
        typeof(LearnHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class LearnConsoleApiClientModule : AbpModule
    {
        
    }
}
