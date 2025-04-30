using Logic;
using Logic.DTOs.Requests;
using Logic.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserLogic logic;

        public UserController(UserLogic logic)
        {
            this.logic = logic;
        }

        // függvények
        [HttpPost]
        [Route("create_user")]
        public UserResponse CreateUser([FromBody] UserCreateRequest request)
        {
            return logic.CreateUser(request);
        }

        [HttpGet]
        [Route("get_user/{id}")]
        public UserResponse GetUser(int id)
        {
            return logic.GetUser(id);
        }

        [HttpPost]
        [Route("get_user")]
        public UserResponse GetUser([FromBody] UserLoginRequest request)
        {
            return logic.GetUser(request.Name, request.Password);
        }


        // új
        [HttpGet]
        [Route("get_users")]
        public List<UserResponse> GetUsers()
        {
            return logic.GetUsers();
        }

        [HttpDelete]
        [Route("delet_user/{id}")]
        public void DeleteUser(int id)
        {
            logic.DeleteUser(id);
        }
    }
}
