using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.DataAccess.Enitites
{
    public class Kill : BaseEntity
    {
        public int UserId { get; set; }
        public int EnemyId { get; set; }
        public int Count { get; set; }
    }
}
