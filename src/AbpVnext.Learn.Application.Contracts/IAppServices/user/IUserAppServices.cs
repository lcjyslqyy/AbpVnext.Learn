using AbpVnext.Learn.Dtos.user;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
namespace AbpVnext.Learn.IAppServices
{
    public interface IUserAppServices : IApplicationService
    {
        Task<UserDto> LoginByUserPhoneAndPwd(string user_phone, string pass_word);
    }
}
