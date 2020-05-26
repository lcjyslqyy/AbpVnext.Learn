using System;
using System.Collections.Generic;
using System.Text;

namespace AbpVnext.Learn.HttpClientModel.Wechat
{
    //微信获取Access_Token的模型
    public class WechatAccessTokenModel: BaseWechatModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
