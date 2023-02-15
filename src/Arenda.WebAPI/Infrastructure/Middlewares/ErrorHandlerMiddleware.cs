using Arenda.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net.Mime;
using System.Text.Json;

namespace Arenda.WebAPI.Infrastructure.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var exceptionResponse = new ExceptionResponse(ex.Message);
                var statusCode = 0;
                statusCode = ex switch
                {
                    FluentValidation.ValidationException => 200,
                    ApplicationException => 400,
                    SecurityTokenValidationException => 401,
                    _ => 500,
                };
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var json = JsonSerializer.Serialize(exceptionResponse);
                await context.Response.WriteAsync(json, context.RequestAborted);
            }
        }
    }
}
