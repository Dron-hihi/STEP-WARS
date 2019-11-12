namespace StepWars.DataAccess.Context
{
    using StepWars.DataAccess.Enitites;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GameDBContext : DbContext
    {
        public GameDBContext() : base("name=GameDBContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Kill> Kills { get; set; }
    }

}