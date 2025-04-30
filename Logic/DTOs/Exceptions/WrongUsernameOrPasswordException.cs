using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs.Exceptions
{
    public class WrongUsernameOrPasswordException : Exception
    {
        public WrongUsernameOrPasswordException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
