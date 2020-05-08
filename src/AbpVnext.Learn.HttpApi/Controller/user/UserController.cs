using AbpVnext.Learn.Dtos.user;
using AbpVnext.Learn.IAppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbpVnext.Learn.Controller.user
{
    [Route("user")]
    public class UserController: LearnController
    {
        private readonly IUserAppServices _userAppServices;
        public UserController(IUserAppServices userAppServices)
        {
            _userAppServices = userAppServices;
        }
        /// <summary>
        /// 获取用户信息，出参UserDto，入参无
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("init")]
        [Authorize]
        public async Task<ResultModel<UserDto>> Init()
        {
            var user =await _userAppServices.get_userbyuserid(new Guid(userid));
            return new ResultModel<UserDto>(200, "", user);
        }
    }
}
