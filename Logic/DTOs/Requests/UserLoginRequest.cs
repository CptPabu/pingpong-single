using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs.Requests
{
    public class UserLoginRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
