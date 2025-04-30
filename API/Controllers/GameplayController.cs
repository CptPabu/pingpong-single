using Logic;
using Logic.DTOs.Requests;
using Logic.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameplayController : ControllerBase
    {
        private GameplayLogic logic;

        public GameplayController(GameplayLogic logic)
        {
            this.logic = logic;
        }

        // függvények
        [HttpPost]
        [Route("/create_game")]
        public GameResponse CreateGame([FromBody] GameCreateRequest request)
        {
            return logic.CreateGame(request);
        }

        [HttpGet]
        [Route("/get_game/{id}")]
        public GameResponse GetGame(int id)
        {
            return logic.GetGame(id);
        }

        [HttpPut]
        [Route("/update_game/{id}")]
        public void UpdateGame(int id, [FromBody] GamestateUpdateRequest request)
        {
            logic.UpdateGame(id, request);
        }




        [HttpGet]
        [Route("/get_games")]
        public List<GameResponse> GetGames()
        {
            return logic.GetGames();
        }

        [HttpDelete]
        [Route("/delete_game/{id}")]
        public void DeleteGame(int id)
        {
            logic.DeleteGame(id);
        }
    }
}
