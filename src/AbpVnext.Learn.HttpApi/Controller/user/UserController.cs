using AbpVnext.Learn.Dtos.user;
using AbpVnext.Learn.IAppServices;
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
        [Route("get")]
        [HttpPost]
        public async Task<UserDto> get([FromBody] GetUserDto model)
        {
            return await _userAppServices.get_userbyuserid(model.userid);
        }
        [Route("get1")]
        [HttpPost]
        public async Task<UserDto>  get1([FromBody] GetUserDto model)
        {
            return await _userAppServices.get_userbyuserid1(model.userid);
        }
        [Route("insert")]
        [HttpGet]
        public async Task<object> insert()
        {
            return await _userAppServices.insert();
        }
    }
}
