using AbpVnext.Learn.Entitys;
using Refit;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AbpVnext.Learn.IHttpClient
{
    /// <summary>
    /// 内部接口，用于调用内部的api服务
    /// </summary>
    public interface IInnerApi
    {
        //内部接口测试
        [Post("/openapi/get")]
        Task<ResultModel<Dictionary<string, string>>> get([Header("Authorization")] string authorization);
    }
}
