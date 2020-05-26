using AbpVnext.Learn.HttpClientModel.Wechat;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbpVnext.Learn.IHttpClient
{
    public interface IWechatApi
    {
        //获取微信公众号的access_token
        [Get("/cgi-bin/token")]
        Task<WechatAccessTokenModel> get_accesstoken(string appid, string secret, string grant_type = "client_credential");
    }
}
