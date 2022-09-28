using Anime.Domain.Exceptions;
using Anime.Domain.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Anime.Api.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<AppExceptionFilterAttribute> _Logger;
        private readonly IConfiguration _Configuration;

        public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger, IConfiguration configuration)
        {
            _Logger = logger;
            _Configuration = configuration;
        }
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var message = context.Exception.Message;

            if (!(context.Exception is AppException))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _Logger.LogError(context.Exception, nameof(AppException));
            }
            else if (context.Exception is ApiJikanException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _Logger.LogError(context.Exception, nameof(ApiJikanException));
            }
            else
            {
                _Logger.LogError(context.Exception, "InternalServerError");
            }

            var msg = new
            {
                message,
                ExceptionType = context.Exception.GetType().ToString()
            };

            context.Result = new ObjectResult(msg);
        }
    }
}
