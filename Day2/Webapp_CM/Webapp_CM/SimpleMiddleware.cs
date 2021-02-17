using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Webapp_CM
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SimpleMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("<div>Hello from Simple Middleware 1</div>");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("<div>Return from Simple Middleware 1</div>");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SimpleMiddlewareExtensions
    {
        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleMiddleware>();
        }
    }
}
