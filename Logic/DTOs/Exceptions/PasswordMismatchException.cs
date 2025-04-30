using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs.Exceptions
{
    public class PasswordMismatchException : Exception
    {
        public PasswordMismatchException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
