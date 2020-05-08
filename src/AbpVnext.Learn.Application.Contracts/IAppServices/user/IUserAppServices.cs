using AbpVnext.Learn.Dtos.user;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
namespace AbpVnext.Learn.IAppServices
{
    public interface IUserAppServices : IApplicationService
    {
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="user_phone"></param>
        /// <param name="pass_word"></param>
        /// <returns></returns>
        Task<UserDto> LoginByUserPhoneAndPwd(string user_phone, string pass_word);
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Task<UserDto> get_userbyuserid(Guid userid);
    }
}
