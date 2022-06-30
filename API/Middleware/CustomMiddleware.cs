using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomMiddleware> logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                logger.LogInformation("Request {method} {url} => {statusCode} \n\t exceção: {excecao}",
                    context.Request?.Method, context.Request?.Path.Value, context.Response?.StatusCode, ex.Message);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(ex);

            return context.Response.WriteAsync(result);
        }

        private int GetStatusCode(Exception ex)
        {
            switch (ex)
            {
                case SecurityTokenException:
                case UnauthorizedAccessException:
                    return 401;
                case KeyNotFoundException:
                    return 404;
                default:
                    return (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
