using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

using Repository.Interfaces;





namespace Repository.Repositories
{
    public class UserRepository : IRepositoryUser
    {
        private readonly DatabaseContext context;


        // Constructor
        public UserRepository(DatabaseContext context)
        {
            this.context = context;
        }


        // Create
        public User Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        // Read
        public User Get(int id)
        {
            return context.Users.Where(p => p.Id == id).First();
        }
        public User Get(string name, string password)
        {
            return context.Users.Where(
                p => p.Name == name &&
                p.Password == password)
                .First();
        }
        public IQueryable<User> GetAll()
        {
            return context.Users;
        }

        // Update
        public void Update()
        {
            context.SaveChanges();
        }

        // Delete
        public void Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
