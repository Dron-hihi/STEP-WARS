namespace StepWars.DataAccess.Context
{
    using StepWars.DataAccess.Enitites;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GameDbContext : DbContext
    {
        public GameDbContext() : base("name=GameDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Enemy> Enemy { get; set; }
        public DbSet<Kill> Kills { get; set; }
    }
}