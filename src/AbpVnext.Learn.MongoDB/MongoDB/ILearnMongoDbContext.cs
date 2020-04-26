using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace AbpVnext.Learn.MongoDB
{
    [ConnectionStringName(LearnDbProperties.ConnectionStringName)]
    public interface ILearnMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
