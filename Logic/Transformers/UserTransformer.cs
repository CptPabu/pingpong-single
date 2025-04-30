using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Logic.DTOs.Requests;
using Logic.Transformers.Interfaces;

using Model;

namespace Logic.Transformers
{
    public class UserTransformer : ITransformer<UserCreateRequest, User>
    {
        public User Transform(UserCreateRequest request)
        {
            User user = new User();
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            return user;
        }

        public List<User> Transform(IQueryable<UserCreateRequest> request)
        {
            List<User> users = new List<User>();
            return users;
        }
    }
}
