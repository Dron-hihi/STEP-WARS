using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.DataAccess.Enitites
{
    public class StarShip : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
    }  
}