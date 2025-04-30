using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

using Repository.Interfaces;





namespace Repository.Repositories
{
    public class ScoreRepository : IRepository<Score>
    {
        private readonly DatabaseContext context;


        // Constructor
        public ScoreRepository(DatabaseContext context)
        {
            this.context = context;
        }


        // Create
        public Score Create(Score score)
        {
            context.Scores.Add(score);
            context.SaveChanges();
            return score;
        }

        // Read
        public Score Get(int id)
        {
            return context.Scores.Where(p => p.Id == id).First();
        }
        public IQueryable<Score> GetAll()
        {
            return context.Scores;
        }

        // Update
        public void Update()
        {
            context.SaveChanges();
        }

        // Delete
        public void Delete(Score score)
        {
            context.Scores.Remove(score);
            context.SaveChanges();
        }
    }
}
