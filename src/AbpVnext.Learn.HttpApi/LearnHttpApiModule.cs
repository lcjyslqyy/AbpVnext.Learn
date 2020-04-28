using Localization.Resources.AbpUi;
using AbpVnext.Learn.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Text;

namespace AbpVnext.Learn
{
    [DependsOn(
        typeof(LearnApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class LearnHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(LearnHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<LearnResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
            var configuration = context.Services.GetConfiguration();
            context.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration.GetValue<string>("JwtAuth:Audience"),
                    ValidIssuer = configuration.GetValue<string>("JwtAuth:Issuer"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetValue<string>("JwtAuth:SecurityKey")))
                };
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        //此处代码为终止.Net Core默认的返回类型和数据结果，这个很重要哦，必须
                        context.HandleResponse();
                        var payload = "{\"ret\":401,\"err\":\"无登录信息或登录信息已失效，请重新登录。\"}";
                        //自定义返回的数据类型
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = StatusCodes.Status200OK;
                        context.Response.WriteAsync(payload);
                        return Task.FromResult(0);
                    }
                };
            });
        }
    }
}
