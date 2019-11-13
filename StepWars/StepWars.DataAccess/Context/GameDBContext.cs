using StepWars.DataAccess.Enitites;
using System;
using System.Data.Entity;
using System.Linq;

namespace StepWars.DataAccess.Context
{
    public class GameDBContext : DbContext
    {
        public GameDBContext() : base("name=GameDBContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Kill> Kills { get; set; }
        public DbSet<StarShip> StarShips { get; set; }
    }
}