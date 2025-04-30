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
    public class UserResponseTransformer : ITransformer<User, UserResponse>
    {
        private ITransformer<Game, GameResponse> gameResponseTransformer;

        public UserResponseTransformer(ITransformer<Game, GameResponse> gameResponseTransformer)
        {
            this.gameResponseTransformer = gameResponseTransformer;
        }

        public UserResponse Transform(User user)
        {
            UserResponse response = new UserResponse();
            response.Id = user.Id;
            response.Name = user.Name;
            response.Games = gameResponseTransformer.Transform(user.Games?.AsQueryable() ?? new List<Game>().AsQueryable());
            return response;
        }
        public List<UserResponse> Transform(IQueryable<User> input)
        {
            List<UserResponse> responseList = new List<UserResponse>();
            foreach (User response in input)
            {
                responseList.Add(Transform(response));
            }
            return responseList;
        }
    }
}
