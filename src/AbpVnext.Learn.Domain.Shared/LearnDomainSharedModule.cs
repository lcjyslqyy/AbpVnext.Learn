using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using AbpVnext.Learn.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace AbpVnext.Learn
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class LearnDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<LearnDomainSharedModule>("AbpVnext.Learn");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<LearnResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Learn");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Learn", typeof(LearnResource));
            });
        }
    }
}
