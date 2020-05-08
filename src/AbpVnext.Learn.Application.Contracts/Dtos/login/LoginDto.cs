using System;
using System.Collections.Generic;
using System.Text;

namespace AbpVnext.Learn.Dtos.login
{
    /// <summary>
    /// 登录的Dto
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string user_phone { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string pass_word { get; set; }
    }
}
