using Volo.Abp.Modularity;

namespace AbpVnext.Learn
{
    [DependsOn(
        typeof(LearnApplicationModule),
        typeof(LearnDomainTestModule)
        )]
    public class LearnApplicationTestModule : AbpModule
    {

    }
}
