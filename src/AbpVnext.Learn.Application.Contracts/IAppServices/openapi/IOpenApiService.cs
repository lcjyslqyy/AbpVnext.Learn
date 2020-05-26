using AbpVnext.Learn.HttpClientModel.InnerApiModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpVnext.Learn.IAppServices.openapi
{
    public interface IOpenApiService: IApplicationService
    {
        Task<Dictionary<string, string>> innerapitest(string token);
    }
}
