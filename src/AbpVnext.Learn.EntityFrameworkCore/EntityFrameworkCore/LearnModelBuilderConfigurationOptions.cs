using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace AbpVnext.Learn.EntityFrameworkCore
{
    public class LearnModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public LearnModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}