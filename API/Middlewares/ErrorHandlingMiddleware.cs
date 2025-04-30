using Logic.DTOs.Exceptions;
using Logic.DTOs.Interfaces;
using Newtonsoft.Json;
using System.Net;

namespace User_Management.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<IExceptionHandler> _exceptionHandlers;

        public ErrorHandlingMiddleware(RequestDelegate next, IEnumerable<IExceptionHandler> exceptionHandlers)
        {
            _next = next;
            _exceptionHandlers = exceptionHandlers;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                foreach (var handler in _exceptionHandlers)
                {
                    if (handler.CanHandle(ex))
                    {
                        await handler.HandleAsync(httpContext, ex);
                        break;
                    }
                }
            }
        }

        /*
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message;
            int statusCode;

            switch (exception)
            {
                case PasswordMismatchException e:
                    message = e.Message;
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case NoUserFoundByIdException e:
                    message = e.Message;
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;

                case WrongUsernameOrPasswordException e:
                    message = e.Message;
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;

                case NoGameFoundByIdException e:
                    message = e.Message;
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;

                case UsernameAlreadyTakenException e2:
                    message = e2.Message;
                    statusCode = (int)HttpStatusCode.Conflict;
                    break;

                default:
                    message = "teapot";
                    statusCode = 418;
                    break;
            }

            var response = new
            {
                status = statusCode,
                msg = message,
            };

            // Log the exception (using any logging framework such as Serilog, NLog, etc.)
            LogError(exception);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        */

        private void LogError(Exception ex)
        {
            // Implement logging logic here (e.g., Serilog, NLog)
        }
    }
}
