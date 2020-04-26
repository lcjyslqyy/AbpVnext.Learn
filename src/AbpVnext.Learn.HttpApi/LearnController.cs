using AbpVnext.Learn.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpVnext.Learn
{
    public abstract class LearnController : AbpController
    {
        protected LearnController()
        {
            LocalizationResource = typeof(LearnResource);
        }
    }
}
