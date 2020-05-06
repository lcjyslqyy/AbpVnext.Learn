using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.Result = new JsonResult(new{ code = 500, err = "系统异常" });
            context.ExceptionHandled = true;
        }
    }
}
