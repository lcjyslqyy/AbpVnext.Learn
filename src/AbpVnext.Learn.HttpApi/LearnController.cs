using AbpVnext.Learn.Localization;
using System;
using System.Security.Claims;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpVnext.Learn
{
    public abstract class LearnController : AbpController
    {
        protected LearnController()
        {
            LocalizationResource = typeof(LearnResource);
        }
        /// <summary>
        /// 登录用户的用户id
        /// </summary>
        protected string userid
        {
            get { return HttpContext.User.Identity.IsAuthenticated ? HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value : ""; }
        }
    }
}
