using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

using Logic.DTOs.Responses;
using Logic.Transformers.Interfaces;

namespace Logic.Transformers
{
    public class GameResponseTransformer : ITransformer<Game, GameResponse>
    {
        private ITransformer<Score, ScoreResponse> scoreResponseTransformer;

        public GameResponseTransformer(ITransformer<Score, ScoreResponse> scoreResponseTransformer)
        {
            this.scoreResponseTransformer = scoreResponseTransformer;
        }

        public GameResponse Transform(Game game)
        {
            GameResponse response = new GameResponse();
            response.Id = game.Id;
            response.BallSpeedLeft = game.BallSpeedLeft;
            response.BallSpeedTop = game.BallSpeedTop;
            response.BallPositionLeft = game.BallPositionLeft;
            response.BallPositionTop = game.BallPositionTop;
            response.BatPositionLeft = game.BatPositionLeft;
            response.IsFinished = game.IsFinished;

            response.UserId = game.UserId;
            response.ScoreId = game.ScoreId;

            response.Score = scoreResponseTransformer.Transform(game.Score);

            return response;
        }
        public List<GameResponse> Transform(IQueryable<Game> input)
        {
            List<GameResponse> responseList = new List<GameResponse>();
            foreach (Game response in input)
            {
                responseList.Add(Transform(response));
            }
            return responseList;
        }
    }
}
