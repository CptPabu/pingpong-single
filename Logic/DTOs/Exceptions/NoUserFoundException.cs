using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs.Exceptions
{
    public class NoUserFoundException : Exception
    {
        public NoUserFoundException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
