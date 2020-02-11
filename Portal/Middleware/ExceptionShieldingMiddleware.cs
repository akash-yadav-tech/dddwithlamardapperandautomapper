using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using POC.Core.Logging;

namespace Portal.Middleware
{
    public static class ExceptionShieldingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionShieldingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionShieldingMiddleware>();
        }
    }
    public class ExceptionShieldingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingService _loggingService;
        public ExceptionShieldingMiddleware(RequestDelegate next, ILoggingService loggingService)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            this._loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // if (context.Response.HasStarted)
                // {

                //     throw;
                // }

                // context.Response.Clear();
                // context.Response.StatusCode = ex.StatusCode;
                // context.Response.ContentType = ex.ContentType;

                //await context.Response.WriteAsync(ex.Message);
                this._loggingService.Error(string.Format("Exception occured Exception Details {0}",ex.ToString()));
                await context.Response.WriteAsync(ex.ToString());
                return;
            }
        }
    }
}
