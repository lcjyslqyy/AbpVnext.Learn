using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AbpVnext.Learn.EntityFrameworkCore.DbMigrations
{
    [ConnectionStringName(LearnDbProperties.ConnectionStringName)]
    public class DbM_LearnDbContext : LearnDbContext
    {
        public DbM_LearnDbContext(DbContextOptions<LearnDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
