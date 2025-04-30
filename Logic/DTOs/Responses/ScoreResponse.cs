using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs.Responses
{
    public class ScoreResponse
    {
        public int Bounces { get; set; }
        public int PlayedSeconds { get; set; }

        public int CalculateScore()
        {
            return Bounces * 5 + PlayedSeconds;
        }
    }
}
