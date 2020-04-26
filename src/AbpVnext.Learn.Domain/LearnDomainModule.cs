using Volo.Abp.Modularity;

namespace AbpVnext.Learn
{
    [DependsOn(
        typeof(LearnDomainSharedModule)
        )]
    public class LearnDomainModule : AbpModule
    {

    }
}
