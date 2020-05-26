using AbpVnext.Learn.Dtos.user;
using AbpVnext.Learn.Entitys;
using AbpVnext.Learn.IAppServices;
using AbpVnext.Learn.IHttpClient;
using AbpVnext.Learn.IRepository;
using AbpVnext.Learn.Redis;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpVnext.Learn.AppServices
{
    public class UserAppServices: ApplicationService,IUserAppServices
    {
        private readonly IUserRepository _repository;
        private readonly IRedisHelper _redis;
        private readonly IWechatApi _wechatApi;
        public UserAppServices(
            IUserRepository repository, IRedisHelper redis, IWechatApi wechatApi)
        {
            _repository = repository;
            _redis = redis;
            _wechatApi = wechatApi;
        }

        public async Task<UserDto> LoginByUserPhoneAndPwd(string user_phone,string pass_word)
        {
            var model=await _wechatApi.get_accesstoken("sssss", "ddddd");
            var user= await _repository.FindAsync(a=>a.user_phone== user_phone&&a.pass_word== pass_word&&a.user_status==0);
            return ObjectMapper.Map<User, UserDto>(user);
        }
        public async Task<UserDto> get_userbyuserid(Guid userid)
        {
            var cachekey = $"user_{userid.ToString()}";
            var userdto_str =await _redis.StringGetAsync(cachekey);
            if (String.IsNullOrEmpty(userdto_str))
            {
                var usermodel = await _repository.get_userinfo(userid);
                if (usermodel != null)
                {
                    var userdto = new UserDto() { Id = usermodel.Id, user_status = usermodel.user_status, user_name = usermodel.user_name, user_phone = usermodel.user_phone };
                    await _redis.StringSetAsync(cachekey, Newtonsoft.Json.JsonConvert.SerializeObject(userdto));
                    return userdto;
                }
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserDto>(userdto_str);
            }
           return null;
        }
        public async Task<UserDto> get_userbyuserid1(Guid userid)
        {
            var usermodel = await _repository.GetAsync(a=>a.Id==userid);
            if (usermodel != null)
            {
                return new UserDto() { user_name = usermodel.user_name, user_phone = usermodel.user_phone };
            }
            return null;
        }
        public async Task<object> insert()
        {
           var model= await _repository.InsertAsync(new Entitys.User() { user_name="name",user_phone= "user_phone",
                user_status=0,create_time=DateTime.Now,pass_word="",UserAuthorizeLists=new List<Entitys.UserAuthorizeList>() { 
            new Entitys.UserAuthorizeList(){ sourceid="123456",sourcetype="weixin",createtime=DateTime.Now,value="6879955222"},
             new Entitys.UserAuthorizeList(){ sourceid="123453336",sourcetype="weixin",createtime=DateTime.Now,value="6879922255222"}
            } });
            return model;
        }
    }
}
