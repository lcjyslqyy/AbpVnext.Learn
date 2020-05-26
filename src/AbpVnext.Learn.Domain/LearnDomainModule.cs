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
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });
            context.Services.AddRefitClient<IWechatApi>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.weixin.qq.com"));
        }
    }
}
