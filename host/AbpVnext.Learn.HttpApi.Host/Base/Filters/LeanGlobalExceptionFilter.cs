using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Validation;

namespace AbpVnext.Learn.Base.Filters
{
    public class LeanGlobalExceptionFilter: IExceptionFilter
    {
        private readonly ILogger<LeanGlobalExceptionFilter> logger;

        public LeanGlobalExceptionFilter( ILogger<LeanGlobalExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
           context.Exception,
           context.Exception.Message);
            if (context.Exception is AbpValidationException)
            {
                var validateerros = ((AbpValidationException)context.Exception).ValidationErrors;
                context.Result = new JsonResult(new  { ode = 100, msg = validateerros.Count > 0 ? validateerros[0].ErrorMessage : context.Exception.Message });
            }
            else
            {
                context.Result = new JsonResult(new { code = 500, msg = "系统异常" });
            }
            context.ExceptionHandled = true;
        }
    }
}
