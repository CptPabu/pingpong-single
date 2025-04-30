using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using Repository.Interfaces;

using Logic.DTOs.Requests;
using Logic.DTOs.Responses;
using Logic.DTOs.Exceptions;
using Logic.Transformers.Interfaces;





namespace Logic
{
    public class UserLogic
    {
        // interface-ek létrehozása
        private readonly IRepositoryUser repository;
        private readonly ITransformer<UserCreateRequest, User> userTransformer;
        private readonly ITransformer<User, UserResponse> responseTransformer;


        // konstruktor
        public UserLogic(
            IRepositoryUser repository,
            ITransformer<UserCreateRequest, User> userTransformer,
            ITransformer<User, UserResponse> responseTransformer
            )
        {
            this.repository = repository;
            this.userTransformer = userTransformer;
            this.responseTransformer = responseTransformer;
        }


        /* CRUD függvények */

        // felhasználó létrehozás
        public UserResponse CreateUser(UserCreateRequest request)
        {
            if (request.Password != request.PasswordCheck)
            {
                throw new PasswordMismatchException("A két jelszó nem egyezik!");
            }
            if (this.IsUsernameTaken(request.Name))
            {
                throw new UsernameAlreadyTakenException("A megadott felhasznalonev mar foglalt");
            }
            User user = userTransformer.Transform(request);
            repository.Create(user);
            return responseTransformer.Transform(user);
        }

        // felhasználó keresés ID alapján
        public UserResponse GetUser(int id)
        {
            try
            {
                return responseTransformer.Transform(repository.Get(id));
            }
            catch
            {
                throw new NoUserFoundException($"Nem létezik felhasználó '{id}' id-val");
            }
        }

        // felhasználó keresés NÉV és JELSZÓ alapján
        public UserResponse GetUser(string name, string password)
        {
            try
            {
                return responseTransformer.Transform(repository.Get(name, password));
            }
            catch
            {
                throw new NoUserFoundException("Hibás felhasználónév vagy jelszó!");
            }
        }

        // összes felhasználó listázása
        public List<UserResponse> GetUsers()
        {
            IQueryable<User> list = repository.GetAll();
            return responseTransformer.Transform(list.AsQueryable());
        }

        // felhasználó adatainak módosítása
        public void UpdateUser(UserUpdateRequest request)
        {
            User User = repository.Get(request.Id);
            User.Name = request.Name;
            User.Email = request.Email;
            User.Password = request.Password;

            repository.Update();
        }

        // felhasználó törlése
        public void DeleteUser(int id)
        {
            User user = repository.Get(id);
            repository.Delete(user);
            repository.Update();
        }


        /* segéd függvények */

        // ellenőrzés, hogy foglalt-e a felhasználónév
        public bool IsUsernameTaken(string username)
        {
            List<UserResponse> users = this.GetUsers();
            foreach (UserResponse user in users)
            {
                if (user.Name == username)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
