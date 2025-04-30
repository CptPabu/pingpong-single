using Model;
using Repository.Interfaces;

using Logic.DTOs.Requests;
using Logic.DTOs.Responses;
using Logic.DTOs.Exceptions;
using Logic.Factories.Interfaces;
using Logic.Transformers.Interfaces;





namespace Logic
{
    public class GameplayLogic
    {
        // interface-ek létrehozása
        private readonly IRepository<Game> gameRepository;
        private readonly IRepository<Score> scoreRepository;
        private readonly IFactory<GameCreateRequest, Game> gameFactory;
        private readonly ITransformer<Game, GameResponse> gameResponseTransformer;


        // konstruktor
        public GameplayLogic
            (
            IRepository<Game> gameRepository,
            IRepository<Score> scoreRepository,
            IFactory<GameCreateRequest, Game> gameFactory,
            ITransformer<Game, GameResponse> gameResponseTransformer
            )
        {
            this.gameRepository = gameRepository;
            this.scoreRepository = scoreRepository;
            this.gameFactory = gameFactory;
            this.gameResponseTransformer = gameResponseTransformer;
        }


        /* CRUD függvények */

        // játék létrehozás (ponttal együtt)
        public GameResponse CreateGame(GameCreateRequest request)
        {
            Game game = gameFactory.Build(request);

            Score baseScore = new Score();
            game.ScoreId = baseScore.Id;
            game.Score = baseScore;

            gameRepository.Create(game);
            return gameResponseTransformer.Transform(game);
        }

        // játék keresés ID alapján
        public GameResponse GetGame(int id)
        {
            GameResponse response;
            try
            {
                response = gameResponseTransformer.Transform(gameRepository.Get(id));
            }
            catch
            {
                throw new NoGameFoundException($"Nem létezik játék '{id}' id-val");
            }
            return response;
        }

        // összes játék listázása
        public List<GameResponse> GetGames()
        {
            IQueryable<Game> list = gameRepository.GetAll();
            return gameResponseTransformer.Transform(list.AsQueryable());
        }

        // játék frissítés
        public void UpdateGame(int gameId, GamestateUpdateRequest request)
        {
            Game game = gameRepository.Get(gameId);
            game.BallSpeedLeft = request.BallSpeedLeft;
            game.BallSpeedTop = request.BallSpeedTop;
            game.BallPositionTop = request.BallPositionLeft;
            game.BallPositionLeft = request.BallPositionTop;
            game.BatPositionLeft = request.BatPositionLeft;
            game.IsFinished = request.IsFinished;

            Score score = scoreRepository.Get(game.ScoreId);
            score.PlayedSeconds = request.PlayedSeconds;
            score.Bounces = request.Bounces;

            gameRepository.Update();
            scoreRepository.Update();
        }

        // játék törlés
        public void DeleteGame(int id)
        {
            Game game = gameRepository.Get(id);
            Score score = scoreRepository.Get(game.ScoreId);

            gameRepository.Delete(game);
            gameRepository.Update();

            scoreRepository.Delete(score);
            scoreRepository.Update();
        }


        /* segéd függvények */

    }
}
