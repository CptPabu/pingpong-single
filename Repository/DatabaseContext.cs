using Microsoft.EntityFrameworkCore;

using Model;





namespace Repository
{
    public class DatabaseContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Score> Scores { get; set; }


        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("dataBase").UseLazyLoadingProxies();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // egy usernek több játéka is lehet
            modelBuilder.Entity<User>()
                .HasMany<Game>(u => u.Games)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId);

            // játék-pontszám 1-1 összetartozik
            modelBuilder.Entity<Game>()
                .HasOne<Score>(g => g.Score)
                .WithOne(s => s.Game)
                .HasForeignKey<Game>(g => g.ScoreId);
        }
    }
}
