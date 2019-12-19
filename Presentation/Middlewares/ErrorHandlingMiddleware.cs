using BusinessLogic.Common.Exceptions;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogExceptionService _logExceptionService;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogExceptionService logExceptionService)
        {
            _next = next;
            _logExceptionService = logExceptionService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int code = (int)HttpStatusCode.InternalServerError;

            string message = exception.Message;

            if (exception is ProjectException)
            {
                code = (exception as ProjectException).StatusCode;
            }

            var userId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            _logExceptionService.Create(exception, context.Request.Path, userId);

            if (code != StatusCodes.Status400BadRequest && code != StatusCodes.Status401Unauthorized && code != StatusCodes.Status404NotFound)
            {
                message = "The server is unavailable.If problem persists contact";
            }

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = code;

            return context.Response.WriteAsync(message);
        }
    }
}
