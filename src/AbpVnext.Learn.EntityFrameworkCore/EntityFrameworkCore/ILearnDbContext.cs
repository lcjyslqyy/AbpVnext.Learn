using AbpVnext.Learn.Entitys;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AbpVnext.Learn.EntityFrameworkCore
{
    [ConnectionStringName(LearnDbProperties.ConnectionStringName)]
    public interface ILearnDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        public DbSet<User> Users { get; set; }
        public DbSet<UserAuthorizeList> UserAuthorizeLists { get; set; }
    }
}