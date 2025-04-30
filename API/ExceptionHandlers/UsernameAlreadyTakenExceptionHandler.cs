using Logic.DTOs.Interfaces;
using Newtonsoft.Json;
using System.Net;
using Logic.DTOs.Exceptions;

namespace User_Management.ExceptionHandlers
{
    public class UsernameAlreadyTakenExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) => exception is UsernameAlreadyTakenException;

        public Task HandleAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;

            var response = new
            {
                status = context.Response.StatusCode,
                message = exception.Message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
