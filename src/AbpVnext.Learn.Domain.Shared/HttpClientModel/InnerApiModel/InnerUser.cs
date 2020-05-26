using System;
using System.Collections.Generic;
using System.Text;

namespace AbpVnext.Learn.HttpClientModel.InnerApiModel
{
    public class InnerUser
    {
        public Guid Id { get; set; }
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
