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
        [HttpPost]
        [Route("logout")]
        //退出登录
        [Authorize]
        public async Task<int> Logout()
        {
            return 0;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ResultModel> Login(string user_phone,string pass_word)
        {
            pass_word = BaseEncrypt.MD5Encrypt(pass_word);
            var user = await _userAppServices.LoginByUserPhoneAndPwd(user_phone, pass_word);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            var dtCreation = DateTime.Now;
            int sss = _configuration.GetValue<int>("JwtAuth:TokenTime");
            var dtExpiration = dtCreation + TimeSpan.FromHours(_configuration.GetValue<int>("JwtAuth:TokenTime"));
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtAuth:SecurityKey")));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = new JwtSecurityToken(_configuration.GetValue<string>("JwtAuth:Issuer"), _configuration.GetValue<string>("JwtAuth:Audience"), claims, dtCreation, dtExpiration, credentials);          
            return new ResultModel(0,"",new { token = handler.WriteToken(securityToken) });
        }
    }
}
