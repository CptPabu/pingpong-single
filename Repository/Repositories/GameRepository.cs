using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

using Repository.Interfaces;





namespace Repository.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private readonly DatabaseContext context;


        // Constructor
        public GameRepository(DatabaseContext context)
        {
            this.context = context;
        }


        // Create
        public Game Create(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
            return game;
        }

        // Read
        public Game Get(int id)
        {
            return context.Games.Where(p => p.Id == id).First();
        }
        public IQueryable<Game> GetAll()
        {
            return context.Games;
        }

        // Update
        public void Update()
        {
            context.SaveChanges();
        }

        // Delete
        public void Delete(Game game)
        {
            context.Games.Remove(game);
            context.SaveChanges();
        }
    }
}
