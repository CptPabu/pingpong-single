using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs.Requests
{
    public class GamestateUpdateRequest
    {
        public int BallSpeedLeft { get; set; }
        public int BallSpeedTop { get; set; }
        public int BallPositionLeft { get; set; }
        public int BallPositionTop { get; set; }
        public int BatPositionLeft { get; set; }
        public bool IsFinished { get; set; }

        public int Bounces { get; set; }
        public int PlayedSeconds { get; set; }
    }
}
