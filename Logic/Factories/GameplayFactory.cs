using Logic.DTOs.Requests;
using Logic.Factories.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Factories
{
    public class GameplayFactory : IFactory<GameCreateRequest, Game>
    {
        public Game Build(GameCreateRequest request)
        {
            Game game = new Game();

            int ballSpeedLeft = 0;
            int ballSpeedTop = 0;

            switch (request.Difficulty)
            {
                case 0:
                    ballSpeedLeft = 5;
                    ballSpeedTop = 5;
                    break;
                case 1:
                    ballSpeedLeft = 10;
                    ballSpeedTop = 10;
                    break;
                case 2:
                    ballSpeedLeft = 20;
                    ballSpeedTop = 20;
                    break;
                default:
                    ballSpeedLeft = 5;
                    ballSpeedTop = 5;
                    break;
            }

            game.BallSpeedLeft = ballSpeedLeft;
            game.BallSpeedTop = ballSpeedTop;
            game.BallPositionTop = 10;
            game.BallPositionLeft = 200;
            game.BatPositionLeft = 200;
            game.IsFinished = false;
            
            game.UserId = request.UserId;

            return game;
        }
    }
}
