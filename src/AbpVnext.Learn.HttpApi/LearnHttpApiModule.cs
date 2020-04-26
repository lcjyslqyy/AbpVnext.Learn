using Localization.Resources.AbpUi;
using AbpVnext.Learn.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace AbpVnext.Learn
{
    [DependsOn(
        typeof(LearnApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class LearnHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(LearnHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<LearnResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
