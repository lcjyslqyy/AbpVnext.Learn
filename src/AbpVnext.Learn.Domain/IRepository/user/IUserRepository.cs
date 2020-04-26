using AbpVnext.Learn.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpVnext.Learn.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> get_userinfo(Guid userid);
    }
}
