using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.DTOs
{
    public class Game
    {
        public int Id { get; set; }
        public int BallSpeedLeft { get; set; }
        public int BallSpeedTop { get; set; }
        public int BallPositionLeft { get; set; }
        public int BallPositionTop { get; set; }
        public int BatPositionLeft { get; set; }
        public bool IsFinished { get; set; }

        public int UserId { get; set; }
        public int ScoreId { get; set; }

        public Game() { }
    }
}
