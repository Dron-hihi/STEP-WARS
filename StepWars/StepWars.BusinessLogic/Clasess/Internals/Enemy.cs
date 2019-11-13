using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.BusinessLogic.Clasess.Internals
{
    public class Enemy : DrawObject
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Hp { get; set; }
    }
}
