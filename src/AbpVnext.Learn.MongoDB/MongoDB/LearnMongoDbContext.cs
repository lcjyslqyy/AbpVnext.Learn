using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace AbpVnext.Learn.MongoDB
{
    [ConnectionStringName(LearnDbProperties.ConnectionStringName)]
    public class LearnMongoDbContext : AbpMongoDbContext, ILearnMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureLearn();
        }
    }
}