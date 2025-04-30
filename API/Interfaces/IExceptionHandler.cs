using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs.Interfaces
{
    public interface IExceptionHandler
    {
        bool CanHandle(Exception exception);
        Task HandleAsync(HttpContext context, Exception exception);
    }
}
