using Logic.DTOs.Interfaces;
using Newtonsoft.Json;
using System.Net;
using Logic.DTOs.Exceptions;

namespace User_Management.ExceptionHandlers
{
    public class DefaultExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) => true;

        public Task HandleAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 418;

            var response = new
            {
                status = context.Response.StatusCode,
                message = "teapot"
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
