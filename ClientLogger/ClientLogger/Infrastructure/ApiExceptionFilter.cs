using ClientLogger.Business.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientLogger.Infrastructure
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            if (context.Exception is RuleViolationException)
            {
                var ex = context.Exception as RuleViolationException;
                context.Exception = null;

                context.HttpContext.Response.StatusCode = 200;
                context.Result = new JsonResult(new { errors = ex.RuleViolations });

            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                context.Result = new JsonResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = 401;

            }
            else
            {
                context.Result = new JsonResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = 500;

            }

            base.OnException(context);
        }
    }
}
