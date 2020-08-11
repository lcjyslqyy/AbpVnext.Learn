using AbpVnext.Learn.IHttpClient;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Volo.Abp.Modularity;
using Refit;
using System;

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
       }
    }
}
