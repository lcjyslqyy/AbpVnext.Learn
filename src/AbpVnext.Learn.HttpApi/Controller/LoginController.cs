using AbpVnext.Learn.Dtos.login;
using AbpVnext.Learn.Encrypt;
using AbpVnext.Learn.IAppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AbpVnext.Learn.Controller
{
    [Route("login")]
    public class LoginController: LearnController
    {
        private readonly IUserAppServices _userAppServices;
        private readonly IConfiguration _configuration;
        public LoginController(IUserAppServices userAppServices, IConfiguration configuration) 
        {
            _userAppServices = userAppServices;
            _configuration = configuration;
        }
        #region 折叠
        /// <summary>
        /// 登出接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("logout")]
        [Authorize]
        public async Task<int> Logout()
        {
            return 0;
        }
        /// <summary>
        /// 用户登录接口，入参：LoginDto，出参LoginOutputDto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<ResultModel<LoginOutputDto>> Login([FromBody]LoginDto dto)
        {
            dto.pass_word = BaseEncrypt.MD5Encrypt(dto.pass_word);
            var user = await _userAppServices.LoginByUserPhoneAndPwd(dto.user_phone, dto.pass_word);
            if (user == null)
            {
                return new ResultModel<LoginOutputDto>(-1, "账号或密码错误，请重新输入",null);
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            var dtCreation = DateTime.Now;
            //Audience
            var dtExpiration = dtCreation + TimeSpan.FromHours(_configuration.GetValue<int>("JwtAuth:TokenTime"));
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtAuth:SecurityKey")));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = new JwtSecurityToken(_configuration.GetValue<string>("JwtAuth:Issuer"), _configuration.GetValue<string>("JwtAuth:Audience"), claims, dtCreation, dtExpiration, credentials);          
            return new ResultModel<LoginOutputDto>(0,"",new LoginOutputDto(){ token = handler.WriteToken(securityToken) });
        }

        #endregion
    }
}
