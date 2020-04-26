using AbpVnext.Learn.Entitys;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AbpVnext.Learn.EntityFrameworkCore
{
    [ConnectionStringName(LearnDbProperties.ConnectionStringName)]
    public class LearnDbContext : AbpDbContext<LearnDbContext>, ILearnDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        #region 用户中心模块相关的表结构
        //用户表
        public DbSet<User> Users { get; set; }
        public DbSet<UserAuthorizeList> UserAuthorizeLists { get; set; }
        #endregion
        public LearnDbContext(DbContextOptions<LearnDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureLearn();
        }
    }
}