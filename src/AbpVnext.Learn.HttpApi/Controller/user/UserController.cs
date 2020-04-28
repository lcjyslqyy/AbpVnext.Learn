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
       
    }
}
