using AbpVnext.Learn.Dtos.user;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
namespace AbpVnext.Learn.IAppServices
{
    public interface IUserAppServices : IApplicationService
    {
        Task<UserDto> get_userbyuserid(Guid userid);
        Task<UserDto> get_userbyuserid1(Guid userid);
        Task<object> insert();
    }
}
