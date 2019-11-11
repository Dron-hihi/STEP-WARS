using StepWars.BusinessLogic.Clasess.Inline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.Internals
{
    public class Bonus : DrawObject
    {
        public Action<StarShip> Effect { get; set; }
        public int Duration { get; set; }
    }
}
