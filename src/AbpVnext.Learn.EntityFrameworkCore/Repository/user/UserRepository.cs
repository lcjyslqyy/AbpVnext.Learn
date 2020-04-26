using AbpVnext.Learn.EntityFrameworkCore;
using AbpVnext.Learn.Entitys;
using AbpVnext.Learn.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AbpVnext.Learn.Repository.user
{
    public class UserRepository :
        EfCoreRepository<LearnDbContext, User>, IUserRepository
    {
        public UserRepository(IDbContextProvider<LearnDbContext> dbContextProvider) :
          base(dbContextProvider)
        {

        }
        public async Task<User> get_userinfo(Guid userid)
        {
            return await this.DbContext.Users.SingleOrDefaultAsync(o => o.Id == userid);
        }
    }
}
