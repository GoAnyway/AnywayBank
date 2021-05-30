using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Resources.AnywayBankApiResources.Middlewares;

namespace AnywayBankApi.Middlewares
{
    internal class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment environment)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                if (environment.IsDevelopment())
                {
                    var error = new { exception.StackTrace, exception.Message };
                    var result = new ObjectResult(error);
                    await result.ExecuteResultAsync(new ActionContext { HttpContext = context });
                }
                else
                {
                    var error = new { Message = ErrorMiddlewareErrors.UnexpectedError };
                    var result = new ObjectResult(error);
                    await result.ExecuteResultAsync(new ActionContext { HttpContext = context });
                }
            }
        }
    }
}