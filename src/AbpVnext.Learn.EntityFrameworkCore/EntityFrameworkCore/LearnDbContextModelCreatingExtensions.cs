using System;
using AbpVnext.Learn.Entitys;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpVnext.Learn.EntityFrameworkCore
{
    public static class LearnDbContextModelCreatingExtensions
    {
        public static void ConfigureLearn(
            this ModelBuilder builder,
            Action<LearnModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new LearnModelBuilderConfigurationOptions(
                LearnDbProperties.DbTablePrefix,
                LearnDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<User>(entity => {
            });
            builder.Entity<UserAuthorizeList>().HasKey(t => new { t.userid, t.sourceid, t.sourcetype });

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
        }
    }
}