using AbpVnext.Learn.Dtos;
using AbpVnext.Learn.Dtos.login;
using AbpVnext.Learn.Dtos.user;
using AbpVnext.Learn.HttpClientModel.InnerApiModel;
using AbpVnext.Learn.IAppServices;
using AbpVnext.Learn.IAppServices.openapi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AbpVnext.Learn.Controller.openapi
{
    [Route("openapi")]
    public class OpenApiController : LearnController
    {
        private readonly IUserAppServices _userAppServices;
        private readonly IConfiguration _configuration;
        private readonly IOpenApiService _openApi;
        public OpenApiController(IUserAppServices userAppServices, IConfiguration configuration, IOpenApiService openApi)
        {
            _userAppServices = userAppServices;
            _configuration = configuration;
            _openApi = openApi;
        }
        /// <summary>
        /// 内部请求调用例子
        /// </summary>
        /// <param name="userdto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("innerapitest")]
        public async Task<ResultModel<Dictionary<string, string>>> innerapitest()
        {

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "innerservice"));
            var dtCreation = DateTime.Now;
            //Audience
            var dtExpiration = dtCreation + TimeSpan.FromHours(_configuration.GetValue<int>("JwtAuth:TokenTime"));
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtAuth:SecurityKey")));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = new JwtSecurityToken(_configuration.GetValue<string>("JwtAuth:Issuer"), _configuration.GetValue<string>("JwtAuth:Audience"), claims, dtCreation, dtExpiration, credentials);
            var token = handler.WriteToken(securityToken);
            var user = await _openApi.innerapitest("Bearer "+token);
            return new ResultModel<Dictionary<string, string>>(200, "", user);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("get")]
        [Authorize(Roles = "innerservice")]
        public async Task<ResultModel<Dictionary<string, string>>> get()
        {
            List<Claim> list = HttpContext.User.Claims.ToList();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var i in list)
            {

                dic.Add(i.Type, i.Value);
            }
            return new ResultModel<Dictionary<string, string>>(200, "", dic);
        }

        /// <summary>
        /// 用于给外部请求此服务接口的授权，入参OpenApiAuthDto ，出参LoginOutputDto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("outauth")]
        public async Task<ResultModel<LoginOutputDto>> outauth([FromBody]OpenApiAuthDto dto)
        {
            if (dto.appid == "123" && dto.appsecret == "456")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "openroles"));
                claims.Add(new Claim("appid", "123"));
                var dtCreation = DateTime.Now;
                //Audience
                var dtExpiration = dtCreation + TimeSpan.FromHours(_configuration.GetValue<int>("JwtAuth:TokenTime"));
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtAuth:SecurityKey")));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var handler = new JwtSecurityTokenHandler();
                var securityToken = new JwtSecurityToken(_configuration.GetValue<string>("JwtAuth:Issuer"), _configuration.GetValue<string>("JwtAuth:Audience"), claims, dtCreation, dtExpiration, credentials);
                return new ResultModel<LoginOutputDto>(0, "", new LoginOutputDto() { token = handler.WriteToken(securityToken) });
            }
            else
            {
                return new ResultModel<LoginOutputDto>(-1, "appid或appsecret错误", null);
            }
        }

    }
}
