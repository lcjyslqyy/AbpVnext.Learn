using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpVnext.Learn.Dtos.user
{
    /// <summary>
    /// 输出用户信息的Dto
    /// </summary>
    public class UserDto: EntityDto<Guid>
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string user_phone { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public int user_status { get; set; }

    }
}
