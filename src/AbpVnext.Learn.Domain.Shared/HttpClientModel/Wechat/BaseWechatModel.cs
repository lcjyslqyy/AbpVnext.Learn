using System;
using System.Collections.Generic;
using System.Text;

namespace AbpVnext.Learn.HttpClientModel.Wechat
{
    public class BaseWechatModel
    {
        //错误时微信会返回错误码
        public int errcode { get; set; }
        //错误信息
        public string errmsg { get; set; }
    }
}
