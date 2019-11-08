using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.DataAccess.Entities
{
    public class Kill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EnemyId { get; set; }
        public int Count { get; set; }

        public User User { get; set; }
        public Enemy Enemy { get; set; }
    }
}
