using ExampleService.Domain.Exceptions;
using ExampleService.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ExampleService.Middleware
{
    // TODO: move to nuget
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        protected virtual async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            if (exception is ExampleException exampleException)
            {
                code = exampleException.Status;
            }

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;

            if (code == HttpStatusCode.InternalServerError)
            {
                // TODO: panic
            }

            await response.WriteAsync(JsonConvert.SerializeObject(new ApiResponse(exception)));
        }
    }
}
