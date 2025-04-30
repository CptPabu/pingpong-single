using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs.Requests
{
    public class GameCreateRequest
    {
        public int UserId { get; set; }
        public int Difficulty { get; set; }
    }
}
