using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace AbpVnext.Learn.MongoDB
{
    public static class LearnMongoDbContextExtensions
    {
        public static void ConfigureLearn(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new LearnMongoModelBuilderConfigurationOptions(
                LearnDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}