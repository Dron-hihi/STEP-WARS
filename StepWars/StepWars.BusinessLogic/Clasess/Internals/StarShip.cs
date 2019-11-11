using StepWars.BusinessLogic.Clasess.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.Inline
{
    public class StarShip
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public string Image { get; set; }
        public Bonus Bonus { get; set; }
    }
}
