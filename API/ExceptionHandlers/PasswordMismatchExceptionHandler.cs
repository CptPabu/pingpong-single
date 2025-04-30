using Logic.DTOs.Interfaces;
using Newtonsoft.Json;
using System.Net;
using Logic.DTOs.Exceptions;
using Microsoft.AspNetCore.Http;
using System;

namespace User_Management.ExceptionHandlers
{
    public class PasswordMismatchExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) => exception is PasswordMismatchException;

        public Task HandleAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new
            {
                /*status = context.Response.StatusCode,
                message = exception.Message,*/
                status = 678,
                message = "asd",
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}