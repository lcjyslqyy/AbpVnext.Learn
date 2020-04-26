using AbpVnext.Learn.Localization;
using Volo.Abp.Application.Services;

namespace AbpVnext.Learn
{
    public abstract class LearnAppService : ApplicationService
    {
        protected LearnAppService()
        {
            LocalizationResource = typeof(LearnResource);
            ObjectMapperContext = typeof(LearnApplicationModule);
        }
    }
}
