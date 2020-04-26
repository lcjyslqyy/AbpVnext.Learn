using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace AbpVnext.Learn.MongoDB
{
    public class LearnMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public LearnMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}