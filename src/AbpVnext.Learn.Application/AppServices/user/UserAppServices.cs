using AbpVnext.Learn.Dtos.user;
using AbpVnext.Learn.Entitys;
using AbpVnext.Learn.IAppServices;
using AbpVnext.Learn.IRepository;
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
        public UserAppServices(
            IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserDto> LoginByUserPhoneAndPwd(string user_phone,string pass_word)
        {
            var user= await _repository.GetAsync(a=>a.user_phone== user_phone&&a.pass_word== pass_word&&a.user_status==0);
            return ObjectMapper.Map<User, UserDto>(user);
        }
        public async Task<UserDto> get_userbyuserid(Guid userid)
        {
            var usermodel = await _repository.get_userinfo(userid);
            if (usermodel != null)
            {
                return new UserDto() {Id=usermodel.Id, user_status=usermodel.user_status, user_name=usermodel.user_name,user_phone=usermodel.user_phone };
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
