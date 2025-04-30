using Logic.DTOs.Interfaces;
using Newtonsoft.Json;
using System.Net;
using Logic.DTOs.Exceptions;

namespace User_Management.ExceptionHandlers
{
    public class NoGameFoundExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) => exception is NoGameFoundExceptionHandler;

        public Task HandleAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var response = new
            {
                status = context.Response.StatusCode,
                message = exception.Message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
