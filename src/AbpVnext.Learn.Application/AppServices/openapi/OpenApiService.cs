using AbpVnext.Learn.IAppServices.openapi;
using AbpVnext.Learn.IHttpClient;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpVnext.Learn.AppServices.openapi
{
    public class OpenApiService : ApplicationService, IOpenApiService
    {

        private readonly IInnerApi _innerApi;
        public OpenApiService(IInnerApi innerApi)
        {
            _innerApi = innerApi;
        }
        /// <summary>
        /// 内部接口测试
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> innerapitest(string token)
        {
            var user =await  _innerApi.get(token);
            return user.data;
        }
    }
}
