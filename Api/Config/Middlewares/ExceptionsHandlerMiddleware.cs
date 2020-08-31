using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Reservatio.Models.Exceptions;

namespace Reservatio.Config.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        public static bool IsDevelopment { get; set; }

        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = ex switch
            {
                EntityNotFoundException _ => HttpStatusCode.BadRequest,
                ArgumentNullException _ => HttpStatusCode.BadRequest,
                ArgumentException _ => HttpStatusCode.Conflict,
                InvalidOperationException _ => HttpStatusCode.BadRequest,
                EmailAlreadyRegisteredException _ => HttpStatusCode.Conflict,
                _ => HttpStatusCode.InternalServerError
            };

            var exceptionType = ex.GetType().ShortDisplayName();
            var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
            string result;

            if (IsDevelopment && code == HttpStatusCode.InternalServerError)
            {
                result = JsonSerializer.Serialize(new
                {
                    exception = exceptionType,
                    error = ex.Message,
                    stacTrace = ex.StackTrace,
                    innerException = innerExceptionMessage,
                    source = ex.Source,
                    data = ex.Data
                });
            }
            else
                result = JsonSerializer.Serialize(new
                {
                    exception = exceptionType,
                    error = ex.Message,
                    innerException = innerExceptionMessage
                });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
