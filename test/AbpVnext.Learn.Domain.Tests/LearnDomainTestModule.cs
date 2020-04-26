using AbpVnext.Learn.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpVnext.Learn
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(LearnEntityFrameworkCoreTestModule)
        )]
    public class LearnDomainTestModule : AbpModule
    {
        
    }
}
